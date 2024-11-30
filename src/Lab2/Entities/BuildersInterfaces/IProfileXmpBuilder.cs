using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IProfileXmpBuilder
{
    IProfileXmpBuilder SetName(string name);
    IProfileXmpBuilder SetVoltage(int voltage);
    IProfileXmpBuilder SetFrequency(int frequency);
    ProfileXmp GetResult();
}