namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class PowerSupply : IPrototype<PowerSupply>
{
    public PowerSupply(
        string name,
        int maxWattage)
    {
        Name = name;
        MaxWattage = maxWattage;
    }

    public string Name { get; set; }
    public int MaxWattage { get; set; }

    public PowerSupply Clone()
    {
        return new PowerSupply(Name, MaxWattage);
    }
}