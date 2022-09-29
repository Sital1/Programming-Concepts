namespace DependencyInjection;

public class Dependency
{
    public Type Type { get; set; }
    public DependencyLifeTime LifeTime { get; set; }
    public object Implementation { get; set; }
    public bool Implemented { get; set; }
    
    public Dependency(Type type, DependencyLifeTime dependencyLifeTime)
    {
        Type = type;
        LifeTime = dependencyLifeTime;
    }

    public void AddImplementation(object i)
    {
        Implementation = i;
        Implemented = true;
    }

}