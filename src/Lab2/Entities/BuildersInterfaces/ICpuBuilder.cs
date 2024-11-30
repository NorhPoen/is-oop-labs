using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface ICpuBuilder
{
    ICpuBuilder SetName(string name);
    ICpuBuilder SetClockSpeed(int clockSpeed);
    ICpuBuilder SetCores(int cores);
    ICpuBuilder SetSocket(string socket);
    ICpuBuilder SetIntegratedGraphics(string integratedGraphics);
    ICpuBuilder SetMaximumRamSpeed(int maximumRamSpeed);
    ICpuBuilder SetTdp(int tdp);
    ICpuBuilder SetWattage(int wattage);
    Cpu GetResult();
}