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
        container.AddDependency(typeof(HelloService));
        container.AddDependency<ServiceConsumer>();
        var resolver = new DependencyResolver(container);

        var service = resolver.GetService<ServiceConsumer>();

        service.Print();

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

    public HelloService(MessageService message)
    {
        _message = message;
    }

    public void Print()
    {
        Console.WriteLine(_message.Message());
    }
}

public class MessageService
{
    public string Message()
    {   
        return "Message Service";
    }
}