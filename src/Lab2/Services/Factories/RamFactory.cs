using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class RamFactory : IComponentFactory<Ram>
{
    private readonly IList<Ram> _ramList;

    public RamFactory(IList<Ram> ramList)
    {
        _ramList = new RamDB().AddNewComponent(ramList);
    }

    public RamFactory()
    {
        _ramList = new RamDB().BuildComponentDb();
    }

    public Ram? CreateComponentByName(string componentName)
    {
        return _ramList
            .FirstOrDefault(ram => ram.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}