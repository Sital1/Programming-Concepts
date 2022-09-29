using System;

namespace DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {   
        // manually instantiating classes
        // we are trying to get rid of new keyword
        // var service = new HelloService();
        // var consumer = new ServiceConsumer(service);
        
        
        // // using Reflection API to instantiate an object
        // // manual but the code is instantiating at run time based on knowledge about it self.
        // // typeof gives all the information about class
        // var service = (HelloService)Activator.CreateInstance(typeof(HelloService));
        // var consumer = (ServiceConsumer)Activator.CreateInstance(typeof(ServiceConsumer),service);
        //
        // service.Print();
        // consumer.Print();
        
        // -----------------------------------------------------------
        
        // using Dependency Container and Resolver
       

        var container = new DependencyContainer();
       
        container.AddTransient<HelloService>();
        container.AddTransient<ServiceConsumer>();
        container.AddSingleton<MessageService>();
        var resolver = new DependencyResolver(container);

        var service1 = resolver.GetService<ServiceConsumer>();
        var service2 = resolver.GetService<ServiceConsumer>();
        var service3 = resolver.GetService<ServiceConsumer>();

        service1.Print();
        service2.Print();
        service3.Print();

    }
}

public class ServiceConsumer
{
    private readonly HelloService _helloService;

    public ServiceConsumer(HelloService helloService)
    {
        _helloService = helloService;
    }

    public void Print()
    {
        _helloService.Print();
    }
}

public class HelloService
{
    private readonly MessageService _message;
    private int _random;
    public HelloService(MessageService message)
    {   
        _random = new Random().Next();
        _message = message;
    }

    public void Print()
    {
        Console.WriteLine($"Hello {_random} hello service. {_message.Message()} ");
    }
}

public class MessageService
{
    private int _random;
    public MessageService()
    {
        _random = new Random().Next();
    }

    public string Message()
    {   
        return $"Message Service {_random}";
    }
}