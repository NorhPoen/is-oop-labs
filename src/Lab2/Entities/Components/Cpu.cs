using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Cpu : IPrototype<Cpu>
{
    public Cpu(
        string name,
        int clockSpeed,
        int cores,
        string socket,
        string integratedGraphics,
        int maximumRamSpeed,
        int tdp,
        int wattage)
    {
        Name = name;
        ClockSpeed = clockSpeed;
        Cores = cores;
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        IntegratedGraphics = integratedGraphics ?? throw new ArgumentNullException(nameof(integratedGraphics));
        MaximumRamSpeed = maximumRamSpeed;
        Tdp = tdp;
        Wattage = wattage;
    }

    public string Name { get; set; }
    public int ClockSpeed { get; set; }
    public int Cores { get; set; }
    public string Socket { get; set; }
    public string IntegratedGraphics { get; set; }
    public int MaximumRamSpeed { get; set; }
    public int Tdp { get; set; }
    public int Wattage { get; set; }

    public Cpu Clone()
    {
        return new Cpu(Name, ClockSpeed, Cores, Socket, IntegratedGraphics, MaximumRamSpeed, Tdp, Wattage);
    }
}