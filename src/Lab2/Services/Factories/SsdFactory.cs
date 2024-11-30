using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class SsdFactory : IComponentFactory<Ssd>
{
    private readonly IList<Ssd> _ssdList;

    public SsdFactory(IList<Ssd> ssdList)
    {
        _ssdList = new SsdDB().AddNewComponent(ssdList);
    }

    public SsdFactory()
    {
        _ssdList = new SsdDB().BuildComponentDb();
    }

    public Ssd? CreateComponentByName(string componentName)
    {
        return _ssdList
            .FirstOrDefault(ssd => ssd.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}