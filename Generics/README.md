## Generics

- Generics are used meant to allow us to use `Types` as values
    - Functional => Function as values
    - Reflection => Code as values
    - Expression => Regular values as values

---
#### Old way of doing things

```
#region  Main

Do(5);
Do("Hello World");
Do(new {a =5 });
#endregion Main



// old way of doing things
static void Do(object v)
{
    Console.WriteLine($"Do something: {v}");
}
```
- What's the problem here?
  - Performance: Until the application actually runs, we don't know what goes into the `Do` method as we are using `object`. There is no type checking. Making mistakes cannot
    be avoided. Cannot perform Compile Time optimization as well. 
  - Hinders readability, understandability and maintainability. In a massive class, there might be confusion. Will the function handle all the different types? Check a 
    lot of places where the function is used and what goes into what. 
  - How do we know if the function can handle the given type when calling it?
---

### Generics syntax

```
/*
 * Generics Syntax
 * Angle brackets to specify the type. Same as giving the name to a variable.
 * Can use the type anywhere in the function. Input can specified to be of that type. Return type as well.
 * Can specify the constrains as well
 */
T Do<T>(T i)
//where T : class
where T: struct // passing string would throw a compile error
{
    return i;
}
```

