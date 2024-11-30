namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Gpu : IPrototype<Gpu>
{
    public Gpu(
        string name,
        int height,
        int width,
        int memory,
        string pcie,
        int coreClock,
        int wattage)
    {
        Name = name;
        Height = height;
        Width = width;
        Memory = memory;
        Pcie = pcie;
        CoreClock = coreClock;
        Wattage = wattage;
    }

    public string Name { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int Memory { get; set; }
    public string Pcie { get; set; }
    public int CoreClock { get; set; }
    public int Wattage { get; set; }

    public Gpu Clone()
    {
        return new Gpu(Name, Height, Width, Memory, Pcie, CoreClock, Wattage);
    }
}