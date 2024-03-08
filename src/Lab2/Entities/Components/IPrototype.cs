namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPrototype<T>
{
    T? Clone();
}