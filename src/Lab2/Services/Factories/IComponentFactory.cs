namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public interface IComponentFactory<T>
{
    T? CreateComponentByName(string componentName);
}