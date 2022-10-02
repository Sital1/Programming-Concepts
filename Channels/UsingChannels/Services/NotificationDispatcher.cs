using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using UsingChannels.Services.Data;

namespace UsingChannels.Services;

public class NotificationDispatcher : BackgroundService
{
    private readonly Channel<string> _channel;
    private readonly ILogger<NotificationDispatcher> _logger;

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IServiceProvider _provider;

    public NotificationDispatcher(
        Channel<string> channel,
        ILogger<NotificationDispatcher> logger,
        IHttpClientFactory httpClientFactory,
        IServiceProvider provider)
    {
        _channel = channel;
        _logger = logger;
        this._httpClientFactory = httpClientFactory;
        _provider = provider;
    }

    // this is the consumer and is going to read from the notification channel
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!_channel.Reader.Completion.IsCompleted) // if not complete
        {
            // read from channel
            var msg = await _channel.Reader.ReadAsync();

            // send notification
            try
            {
                using (var scope = _provider.CreateScope())
                {
                    var _database = scope.ServiceProvider.GetRequiredService<Database>();
                    if (!await _database.Users.AnyAsync())
                    {
                        _database.Users.Add(new User());
                        await _database.SaveChangesAsync();
                    }

                    var user = await _database.Users.FirstOrDefaultAsync();

                    var client = _httpClientFactory.CreateClient();
                    // sending notification. Not a simple thing.
                    var response = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/core/");
                    // save in db
                    user.Message = response;

                    await _database.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Notification Failed");
            }
        }
    }
}