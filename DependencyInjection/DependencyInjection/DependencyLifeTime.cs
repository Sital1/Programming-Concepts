namespace DependencyInjection;

/// <summary>
/// Transient objects are always different; a new instance is provided to every controller and every service.
///Scoped objects are the same within a request, but different across different requests.
///Singleton objects are the same for every object and every request.
/// </summary>
public enum DependencyLifeTime
{
    Singleton = 0,
    Transient = 1
}