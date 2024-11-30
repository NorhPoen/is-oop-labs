using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class CpuCoolerFactory : IComponentFactory<CpuCooler>
{
    private readonly IList<CpuCooler> _coolerList;

    public CpuCoolerFactory(IList<CpuCooler> coolerList)
    {
        _coolerList = new CpuCoolerDB().AddNewComponent(coolerList);
    }

    public CpuCoolerFactory()
    {
        _coolerList = new CpuCoolerDB().BuildComponentDb();
    }

    public CpuCooler? CreateComponentByName(string componentName)
    {
        return _coolerList
            .FirstOrDefault(cooler => cooler.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}