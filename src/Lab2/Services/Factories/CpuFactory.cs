using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class CpuFactory : IComponentFactory<Cpu>
{
    private readonly IList<Cpu> _cpuList;

    public CpuFactory(IList<Cpu> cpuList)
    {
        _cpuList = new CpuDB().AddNewComponent(cpuList);
    }

    public CpuFactory()
    {
        _cpuList = new CpuDB().BuildComponentDb();
    }

    public Cpu? CreateComponentByName(string componentName)
    {
        return _cpuList
            .FirstOrDefault(cpu => cpu.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}