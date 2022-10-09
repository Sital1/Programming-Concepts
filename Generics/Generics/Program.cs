// See https://aka.ms/new-console-template for more information


// Duck is eating Seeds at a Pond

using System;

new Duck().Eat(new Seeds());

// looks ugly
new AnimalFeedingContext<Duck, Seeds, Pond>(new Duck())
    .Arrive()
    .Feed(new Seeds());

// Not ugly
Factory.Create(new Duck());

// Example Application


public class Factory
{
    public static AnimalFeedingContext<Animal<F, L>,F, L> Create<F,L>(Animal<F, L> a)
        where F : Food
        where L : Location
    {
        return new AnimalFeedingContext<Animal<F, L>,F, L>(a);
    }
}


// An Animal eats certain type of Food and stays at a certain location
public abstract class Animal<F, L>
    where F : Food
    where L : Location
{
    public void Eat(F food)
    {
        Console.WriteLine($"{this.GetType().Name} is eating {typeof(F).Name} at a {typeof(L).Name}");
    }
}

// An animal

// // IF there is no type where clause in Animal class, nothing stops us
// // From making a Duck that eats Pond and sits in a seed.
// public class Duck : Animal<Pond, Seeds> { }

// A duck that eats seeds and sits in a pond.
public class Duck : Animal<Seeds, Pond>
{
}


// Food has to be of Type Food
public interface Food
{
}

public class Bread : Food
{
}

public class Seeds : Food
{
}


// Location has to be a type of Food
public interface Location
{
}

public class Pond : Location
{
}

public class Lake : Location
{
}


public class AnimalFeedingContext<A, F, L>
    where A : Animal<F, L>
    where F : Food
    where L : Location
{
    private readonly Animal<F, L> _animal;

    public AnimalFeedingContext(Animal<F, L> animal)
    {
        _animal = animal;
    }

    public AnimalFeedingContext<A, F, L> Arrive()
    {
        Console.WriteLine($"Arrived at {typeof(L).Name}");
        return this;
    }

    public void Feed(F food)
    {
        _animal.Eat(food);
    }

}





// #region  Main
//
//
// // Do("Hello World");
// // Do(new {a =5 });
//
// Do<A, int>(new A());
// #endregion Main
//
//
// // Generic parameters
// // R is the return type
// R Do<T,R>(T i)
// //where T : class
//     where T: A, new()
// {
//     Console.WriteLine(i);
//
//     return Activator.CreateInstance<R>(); // cannot call this if new() not specified
// }
//
//
//
// public class A
// {
//     public A()
//     {
//         Console.WriteLine(++i);
//     }
//     public static int i = 0;
// }
//
//
//
// // // old way of doing things
// // static void Do(object v)
// // {
// //     Console.WriteLine($"Do something: {v}");
// // }
//
// /*
//  * Generics Syntax
//  * Angle brackets to specify the type. Same as giving the name to a variable.
//  * Can use the type anywhere in the function. Input can specified to be of that type. Return type as well.
//  * Can specify the constrains as well
//  */
// // void Do<T>(T i)
// // //where T : class
// //     where T: class, new()
// // {
// //    Console.WriteLine(i);
// // }
//
// // T Do<T>(T i)
// // //where T : class
// //     where T: A, new()
// // {
// //     Console.WriteLine(i);
// //
// //     return new T(); // cannot call this if new() not specified
// // }
//