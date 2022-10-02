namespace Channels;

public class MainProgram
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
            //SendNotification();
            
            // this can be tempting to do
            // the problem is the scope
            // we usually reslove a service using dependency injection.
            // because we exit the scope of the service before the notification is finished
            // the DI is disposed. When the SendNotification() tries to consume it, the problem arises
            // We might wanna use Channel. Put a message of what we want to send in the channel. When the service is ready, it can pick it  up.
            Task.Run(()=>SendNotification());
        }
    }

    public static void SendNotification()
    {   
        // A blocking operation
        // In a sense of user making a request to the service.
        // Doesn't matter which thread does it, the user is waiting.
        Task.Delay(1000).GetAwaiter().GetResult();
    }
}