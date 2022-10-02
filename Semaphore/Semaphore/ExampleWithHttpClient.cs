namespace Semaphore;

public class ExampleWithHttpClient
{
    private static HttpClient _client = new HttpClient()
    {
        Timeout = TimeSpan.FromSeconds(5)
    };

    private static SemaphoreSlim _gate = new SemaphoreSlim(1);

    public static void Main()
    {   
        // We create 1000 task and run all of them.
        // The computer is fast to run the CallGoogle function and tell the network card to fetch it.
        // That happens 1000 times. The NC is not that fast.
        // The timeout start after calling the function, not when the network card start processing
        // Similar to example in Program.cs, we want to guard the process. After one finishes, let other come.
        Task.WaitAll(CreateCalls().ToArray());
    }

    public static IEnumerable<Task> CreateCalls()
    {
        for (int i = 0; i < 1000; i++)
        {   
            yield return CallGoogle();
        }
    }

    public static async Task CallGoogle()
    {   
        // guard the process.
        try
        {
            await _gate.WaitAsync();
            var response = await _client.GetAsync("https://google.com");
            _gate.Release();
            Console.WriteLine("here");
            Console.WriteLine(response.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}