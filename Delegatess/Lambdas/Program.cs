namespace Lambdas;

public class Program
{   
    public static void Main(string[] args)
    {

        // On high level, lambda is an anonymous function. It is separate from Delegate, Action, Func. Delegate represent function.
        // Delegate is a container where function goes
        GetNumber getN = () => 5;
        Console.WriteLine(getN());
        
        // closure. Adding value to scope of the obj where the function is being performed.
        // 
        int i = 5;
        GetNumber getNC = () => 5 + i;
        Console.WriteLine(getN());
    }

    delegate int GetNumber();
}