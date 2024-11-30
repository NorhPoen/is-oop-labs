using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IGpuBuilder
{
    IGpuBuilder SetName(string name);
    IGpuBuilder SetHeight(int height);
    IGpuBuilder SetWidth(int width);
    IGpuBuilder SetMemory(int memory);
    IGpuBuilder SetPcie(string pcie);
    IGpuBuilder SetCoreClock(int coreClock);
    IGpuBuilder SetWattage(int wattage);
    Gpu GetResult();
}