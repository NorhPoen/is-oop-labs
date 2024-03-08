namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class MotherBoard : IPrototype<MotherBoard>
{
    public MotherBoard(
        string name,
        string socketCpu,
        int pcieLines,
        int slotsSata,
        string chipset,
        string ddrStandard,
        int ddrSlots,
        string formFactor,
        string ramFormFactor,
        Bios bios)
    {
        Name = name;
        SocketCpu = socketCpu;
        PcieLines = pcieLines;
        SlotsSata = slotsSata;
        Chipset = chipset;
        DdrStandard = ddrStandard;
        DdrSlots = ddrSlots;
        FormFactor = formFactor;
        RamFormFactor = ramFormFactor;
        Bios = bios;
    }

    public string Name { get; set; }
    public string SocketCpu { get; set; }
    public int PcieLines { get; set; }
    public int SlotsSata { get; set; }
    public string Chipset { get; set; }
    public string DdrStandard { get; set; }
    public int DdrSlots { get; set; }
    public string FormFactor { get; set; }
    public string RamFormFactor { get; set; }
    public Bios Bios { get; set; }

    public MotherBoard Clone()
    {
        return new MotherBoard(Name, SocketCpu, PcieLines, SlotsSata, Chipset, DdrStandard, DdrSlots, FormFactor, RamFormFactor, Bios);
    }
}