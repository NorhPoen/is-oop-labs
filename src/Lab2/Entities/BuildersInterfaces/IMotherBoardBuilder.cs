using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder SetName(string name);
    IMotherBoardBuilder SetSocketCpu(string socketCpu);
    IMotherBoardBuilder SetPcieLines(int pcieLines);
    IMotherBoardBuilder SetSlotsSata(int slotsSata);
    IMotherBoardBuilder SetChipset(string chipset);
    IMotherBoardBuilder SetDdrStandard(string ddrStandard);
    IMotherBoardBuilder SetDdrSlots(int ddrSlots);
    IMotherBoardBuilder SetFormFactor(string formFactor);
    IMotherBoardBuilder SetRamFormFactor(string ramFormFactor);
    IMotherBoardBuilder SetBios(Bios bios);
    MotherBoard GetResult();
}