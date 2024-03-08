using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IHddBuilder
{
    IHddBuilder SetName(string name);
    IHddBuilder SetCapacity(int capacity);
    IHddBuilder SetSpindleSpeed(int spindleSpeed);
    IHddBuilder SetWattage(int wattage);
    Hdd GetResult();
}