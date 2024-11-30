namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Hdd : IPrototype<Hdd>
{
    public Hdd()
    {
        Name = "NullHdd";
    }

    public Hdd(
        string name,
        int capacity,
        int spindleSpeed,
        int wattage)
    {
        Name = name;
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        Wattage = wattage;
    }

    public string Name { get; set; }
    public int Capacity { get; set; }
    public int SpindleSpeed { get; set; }
    public int Wattage { get; set; }

    public Hdd Clone()
    {
        return new Hdd(Name, Capacity, SpindleSpeed, Wattage);
    }
}