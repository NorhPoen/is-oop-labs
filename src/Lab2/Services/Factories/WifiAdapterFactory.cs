using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class WiFiAdapterFactory : IComponentFactory<WiFiAdapter>
{
    private readonly IList<WiFiAdapter> _wiFiAdapterList;

    public WiFiAdapterFactory(IList<WiFiAdapter> wiFiAdapterList)
    {
        _wiFiAdapterList = new WiFiAdapterDb().AddNewComponent(wiFiAdapterList);
    }

    public WiFiAdapterFactory()
    {
        _wiFiAdapterList = new WiFiAdapterDb().BuildComponentDb();
    }

    public WiFiAdapter? CreateComponentByName(string componentName)
    {
        return _wiFiAdapterList
            .FirstOrDefault(adapter => adapter.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))
            ?.Clone();
    }
}