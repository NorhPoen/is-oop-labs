using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IPowerSupplyBuilder
{
    IPowerSupplyBuilder SetName(string name);
    IPowerSupplyBuilder SetMaxWattage(int maxWattage);
    PowerSupply GetResult();
}