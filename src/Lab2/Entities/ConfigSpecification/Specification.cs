using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ConfigSpecification;

public class Specification
{
    public Specification(string cpu, string casePc, string cpuCooler, string powerSupply, string motherBoard, string? gpu, string? wiFiAdapter, IList<string> ram, IList<string>? ssd, IList<string>? hdd)
    {
        Cpu = cpu;
        CasePc = casePc;
        CpuCooler = cpuCooler;
        PowerSupply = powerSupply;
        MotherBoard = motherBoard;
        Gpu = gpu;
        WiFiAdapter = wiFiAdapter;
        Ram = ram;
        Ssd = ssd;
        Hdd = hdd;
    }

    public string Cpu { get; init; }
    public string CasePc { get; init; }
    public string CpuCooler { get; init; }
    public string PowerSupply { get; init; }
    public string MotherBoard { get; init; }
    public string? Gpu { get; init; }
    public string? WiFiAdapter { get; init; }
    public IList<string> Ram { get; init; }
    public IList<string>? Ssd { get; init; }
    public IList<string>? Hdd { get; init; }
}