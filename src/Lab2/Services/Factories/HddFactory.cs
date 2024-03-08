using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class HddFactory : IComponentFactory<Hdd>
{
    private readonly IList<Hdd> _hddList;

    public HddFactory(IList<Hdd> hddList)
    {
        _hddList = new HddDB().AddNewComponent(hddList);
    }

    public HddFactory()
    {
        _hddList = new HddDB().BuildComponentDb();
    }

    public Hdd? CreateComponentByName(string componentName)
    {
        return _hddList
            .FirstOrDefault(hdd => hdd.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}