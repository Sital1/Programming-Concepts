namespace Delegatess;

public class Program
{
    public static void Main(string[] args)
    {
        ///// DrinkingWater();
        // DrinkingBeer();
        // DrinkingLemonade();
        
        // The thing we want to do is hiding inside an object
        // The thing we want to do, drinking something is the thing we need. The interface, class needs so that we can have the function.
        // What's important is the the thing we want to do, not the classes and such stuff.
        // Delegate is the syntax we come up with to remove these boilerplate
        //RelaxingOnTheBeach(new DrinkWaterO());
        
        
        // passing the function without ()
        // Less code and reusable
        // RelaxingOnTheBeach(DrinkingWater);
        // RelaxingOnTheBeach(DrinkingBeer);
        // RelaxingOnTheBeach(DrinkingLemonade);
        // Run(DrinkingBeer);
        //
        // var drinkingAction = new DrinkingAction(DrinkingWater);
        // // Invoke the function
        // drinkingAction();
        
        // Func is just a generic Delegate
        //public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        Func<int, int, int> add = (int a, int b) => a + b;
        Console.WriteLine(add(1,1));
        
        // Action is also a generic delegate   public delegate void Action<in T>(T obj);
        // Func has a return type. Action is void. 
        Action<int> printNumber = n => Console.WriteLine(n);
        
        // with parameters
        Action<int, int, int> print3numbers = (a, b, c) => Console.WriteLine($"{a}{b}{c}");
        
        printNumber(1);
        print3numbers(1,2,3);
        RelaxingOnTheBeach(DrinkingWater);
        RelaxingOnTheBeach(DrinkingBeer);
        RelaxingOnTheBeach(DrinkingLemonade);
        
        // --------------------------------------------------------- //
      

    }
    
    // these are lambdas
    static void DrinkingWater()=>Console.WriteLine("Drinking Water");
    static void DrinkingBeer()=>Console.WriteLine("Drinking Beer");
    static void DrinkingLemonade()=>Console.WriteLine("Drinking Lemonade");
    
    
    
    // using Action  instead of delegate
    static void RelaxingOnTheBeach(Action drink)
    {
        Console.WriteLine("Relaxing OnThe Beach");
    
        if (drink != null) drink();
    }
    
    
    // Delegate
    /*
     * void DrinkingAction() is the thing we define without and interface.
     * It is similar to the method in the IDrink Interface behind the scene
     */
    delegate void DrinkingAction();
    
    // expecting the interface. But delegate shorten it. Pass the actual function without braces when calling
    // static void RelaxingOnTheBeach(DrinkingAction drink)
    // {
    //     Console.WriteLine("Relaxing OnThe Beach");
    //
    //     if (drink != null) drink();
    // }
    
    static void Run(DrinkingAction drink)
    {
        Console.WriteLine("Running OnThe Beach");
    
        if (drink != null) drink();
    }
    
    
    // ----------------------------------------------------------------------------//
    
    
    
    // interface IDrink
    // {
    //     void Drink();
    // }
    //
    // class DrinkWaterO : IDrink
    // {
    //     public void Drink()
    //     {
    //         Console.WriteLine("Drinking Water");
    //     }
    // }
    // class DrinkBeerO : IDrink
    // {
    //     public void Drink()
    //     {
    //         Console.WriteLine("Drinking Water");
    //     }
    // } 
    // class DrinkLemonadeO : IDrink
    // {
    //     public void Drink()
    //     {
    //         Console.WriteLine("Drinking Water");
    //     }
    // }
    //
    //
    // static void RelaxingOnTheBeach(IDrink drink)
    // {
    //     Console.WriteLine("Relaxing OnThe Beach");
    //
    //     if (drink != null) drink.Drink();
    // }
    //
    
    

    
    
    
    
    // static void RelaxingOnTheBeach()
    // {
    //     Console.WriteLine("Relaxing OnThe Beach");
    // }

    // static void RelaxingOnTheBeachAndDrinkWater()
    // {
    //     Console.WriteLine("Relaxing OnThe Beach");
    //     DrinkingWater();
    // }
    //
    // static void RelaxingOnTheBeachAndDrinkBeer()
    // {
    //     Console.WriteLine("Relaxing OnThe Beach");
    //     DrinkingBeer();
    // }



}