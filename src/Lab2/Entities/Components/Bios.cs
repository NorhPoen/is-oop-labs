using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Bios : IPrototype<Bios>
{
    public Bios(
        string name,
        string biosType,
        string biosVersion,
        IList<string> supportedCpu)
    {
        Name = name;
        BiosType = biosType;
        BiosVersion = biosVersion;
        SupportedCpu = supportedCpu;
    }

    public string Name { get; set; }
    public string BiosType { get; set; }
    public string BiosVersion { get; set; }
    public IList<string> SupportedCpu { get; init; }

    public Bios Clone()
    {
        return new Bios(Name, BiosType, BiosVersion, SupportedCpu);
    }
}