using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IBiosBuilder
{
    IBiosBuilder SetName(string name);
    IBiosBuilder SetBiosType(string biosType);
    IBiosBuilder SetBiosVersion(string biosVersion);
    IBiosBuilder SetSupportedCpu(IList<string> supportedCpu);
    Bios GetResult();
}