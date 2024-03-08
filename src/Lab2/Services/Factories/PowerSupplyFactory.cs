using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class PowerSupplyFactory : IComponentFactory<PowerSupply>
{
    private readonly IList<PowerSupply> _powerSupplyList;

    public PowerSupplyFactory(IList<PowerSupply> powerSupplyList)
    {
        _powerSupplyList = new PowerSupplyDB().AddNewComponent(powerSupplyList);
    }

    public PowerSupplyFactory()
    {
        _powerSupplyList = new PowerSupplyDB().BuildComponentDb();
    }

    public PowerSupply? CreateComponentByName(string componentName)
    {
        return _powerSupplyList
            .FirstOrDefault(powerSupply => powerSupply.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}