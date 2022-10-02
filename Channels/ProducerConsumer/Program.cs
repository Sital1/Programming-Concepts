namespace ProducerConsumer;

public class Program
{
    public static void Main(string[] args)
    {   
        Console.WriteLine("starting ...");
        var channel = new Channel<string>();

        Task.WaitAll( Consumer(channel),Producer(channel),Producer(channel),Producer(channel));
    }
    
    // producer
    public  static async Task Producer(IWrite<string> writer)
    {
        for (int i = 0; i < 100; i++)
        {
            writer.Push(i.ToString());
            await Task.Delay(100);
        }
        writer.Complete();
    }

    // consumer
    public static async Task Consumer(IRead<string> reader)
    {
        while (!reader.IsComplete())
        {
            var msg = await reader.Read();
            Console.WriteLine($"msg: {msg}");
        }
    }
}