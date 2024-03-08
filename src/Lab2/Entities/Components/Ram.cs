using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Ram : IPrototype<Ram>
{
    public Ram(
        string name,
        int capacity,
        int frequency,
        IEnumerable<string> xmps,
        string formFactor,
        string ddrStandart,
        int wattage)
    {
        Name = name;
        Capacity = capacity;
        Frequency = frequency;
        Xmps = xmps;
        FormFactor = formFactor;
        DdrStandart = ddrStandart;
        Wattage = wattage;
    }

    public string Name { get; set; }
    public int Capacity { get; set; }
    public int Frequency { get; set; }
    public IEnumerable<string> Xmps { get; set; }
    public string FormFactor { get; set; }
    public string DdrStandart { get; set; }
    public int Wattage { get; set; }

    public Ram Clone()
    {
        return new Ram(Name, Capacity, Frequency, Xmps, FormFactor, DdrStandart, Wattage);
    }
}