namespace Semaphore;

public class Program
{
    // argument is the amount allowed to go through the gate
    private static SemaphoreSlim gate = new SemaphoreSlim(1);

    public static async Task Main(string[] args)
    {
        /*
         * In this case the output would be
         *  Start
            Do Some work
            Finish
            Start
          * As the semaphore allows only one to enter the city through the gate
         */
        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine("Start");
        //     await gate.WaitAsync();
        //
        //     Console.WriteLine("Do Some work");
        //
        //
        //     Console.WriteLine("Finish");
        // }
        
        /*
         * We could let 10 person enter the building(process). But it is a very small building.
         * One person can enter the building and the next should be notified after the first leaves.
         */
        
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Start");
            await gate.WaitAsync();

            Console.WriteLine("Do Some work");
            // call release to increment the count
            // every one does the work. Only one at a time.
            gate.Release();
            Console.WriteLine("Finish");
        }
        
    }
}