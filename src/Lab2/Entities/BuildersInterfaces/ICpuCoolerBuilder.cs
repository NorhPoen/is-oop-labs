using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface ICpuCoolerBuilder
{
    ICpuCoolerBuilder SetName(string name);
    ICpuCoolerBuilder SetSockets(IEnumerable<string> sockets);
    ICpuCoolerBuilder SetFansSize(int fansSize);
    ICpuCoolerBuilder SetMaxTdp(int maxTdp);
    CpuCooler GetResult();
}