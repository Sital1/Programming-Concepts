namespace DependencyInjection;

public class DependencyContainer
{
    List<Type> _dependencies;

    public void AddDependency(Type type)
    {
        _dependencies = new List<Type>();
        _dependencies.Add(type);
    }

    public void AddDependency<T>()
    {
        _dependencies.Add(typeof(T));
    }

    public Type GetDependency(Type type)
    {
        return _dependencies.First(x => x.Name == type.Name);
    }
}