namespace DependencyInjection;

public class DependencyResolver
{
    DependencyContainer _container;
    public DependencyResolver(DependencyContainer container)
    {
        _container = container;
    }

    public T GetService<T>()
    {
        return (T) GetService(typeof(T));
    }

    /// <summary>
    /// Resolves the service. Using recursion. We want to resolve the service until it has no parameters.
    ///It essentially uses recursion to create necessary services starting from the ones that
    ///don't require parameters and use that to create another service in the chain until required service is generated.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public object GetService(Type type)
    {
        var dependency = _container.GetDependency(type);
        var constructor = dependency.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length > 0)
        {
            var parameterImplementations = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameterImplementations[i] =  GetService(parameters[i].ParameterType);
            }

            return Activator.CreateInstance(dependency, parameterImplementations);
        }


        return Activator.CreateInstance(dependency);
    }
}