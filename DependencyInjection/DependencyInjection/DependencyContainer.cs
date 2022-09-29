using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection;

public class DependencyContainer
{
    List<Dependency> _dependencies;

    public DependencyContainer()
    {
        _dependencies = new List<Dependency>();
    }

    public void AddSingleton<T>()
    {
        _dependencies.Add(new Dependency(typeof(T),DependencyLifeTime.Singleton));
    }

    public void AddTransient<T>()
    {
        _dependencies.Add(new Dependency(typeof(T),DependencyLifeTime.Transient));
    }

    public Dependency GetDependency(Type type)
    {
        return _dependencies.First(x => x.Type.Name == type.Name);
    }
}