using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class CpuCooler : IPrototype<CpuCooler>
{
    public CpuCooler(
        string name,
        IEnumerable<string> sockets,
        int fansSize,
        int maxTdp)
    {
        Name = name;
        Sockets = sockets;
        FansSize = fansSize;
        MaxTdp = maxTdp;
    }

    public string Name { get; set; }
    public int FansSize { get; set; }
    public int MaxTdp { get; set; }
    public IEnumerable<string> Sockets { get; set; }

    public CpuCooler Clone()
    {
        return new CpuCooler(Name, Sockets, FansSize, MaxTdp);
    }
}