namespace DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {   
        // manually instantiating classes
        // we are trying to get rid of new keyword
        var service = new HelloService();
        var consumer = new ServiceConsumer(service);
        service.Print();
        consumer.Print();
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
    public void Print()
    {
        Console.WriteLine("hello world");
    }
}