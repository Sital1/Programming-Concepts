using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using UsingChannels.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddDbContext<Database>(config => config.UseInMemoryDatabase("test"));
builder.Services.AddControllers();
builder.Services.AddTransient<Notifications>();

builder.Services.AddHostedService<NotificationDispatcher>();

//channel. One channel that is a singleton
builder.Services.AddSingleton(Channel.CreateUnbounded<string>());

var app = builder.Build();

app.MapControllers();


app.Run();