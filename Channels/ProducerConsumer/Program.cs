namespace VideoProcessingExample;

public class Program
{
    public static void Main(string[] args)
    {
        
    }
    
    // producer
    public Task Producer(IWrite<string> writer)
    {
        for (int i = 0; i < 100; i++)
        {
            writer.Push(i.ToString());
            Task.Delay(100).GetAwaiter().GetResult();
        }
        writer.Complete();
        return Task.CompletedTask;
    }

    // consumer
    public async Task Consumer(IRead<string> reader)
    {
        while (!reader.IsComplete())
        {
            var msg = await reader.Read();
            Console.Write("msg");
        }
    }
}