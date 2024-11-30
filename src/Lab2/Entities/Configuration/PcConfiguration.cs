using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Configuration;

public class PcConfiguration
{
    public PcConfiguration(MotherBoard motherBoard, Cpu cpu, IList<Ssd>? ssd, IList<Hdd>? hdd, CasePc casePc, PowerSupply powerBlock, IList<Ram> ramSticks, CpuCooler cooler, Gpu? graphicCard, WiFiAdapter? wiFiAdapter)
    {
        MotherBoard = motherBoard;
        Cpu = cpu;
        Ssd = ssd;
        Hdd = hdd;
        CasePc = casePc;
        PowerBlock = powerBlock;
        Ram = ramSticks;
        CpuCooler = cooler;
        GraphicCard = graphicCard;
        WiFiAdapter = wiFiAdapter;
    }

    public MotherBoard MotherBoard { get; init; }
    public Cpu Cpu { get; init; }
    public IList<Ssd>? Ssd { get; init; }
    public IList<Hdd>? Hdd { get; init; }
    public CasePc CasePc { get; init; }
    public PowerSupply PowerBlock { get; init; }
    public IList<Ram> Ram { get; init; }
    public CpuCooler CpuCooler { get; init; }
    public Gpu? GraphicCard { get; init; }
    public WiFiAdapter? WiFiAdapter { get; init; }

    public PcConfiguration? Clone()
    {
        return new PcConfiguration(MotherBoard, Cpu, Ssd, Hdd, CasePc, PowerBlock, Ram, CpuCooler, GraphicCard, WiFiAdapter);
    }
}