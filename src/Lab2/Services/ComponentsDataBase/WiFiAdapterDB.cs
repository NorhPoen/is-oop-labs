using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class WiFiAdapterDb : IBuildComponentDb<WiFiAdapter>
{
    public IList<WiFiAdapter> BuildComponentDb()
    {
        var wifiList = new List<WiFiAdapter>();
        var wifiBuilder = new WifiAdapterBuilder();

        wifiList.Add(wifiBuilder.SetName("TP-LINK Archer T2U Plus")
            .SetStandartVersion("5 (802.11ac)").SetPciVersion("PCI-E")
            .SetBluetooth(false).SetWattage(4).GetResult());

        wifiList.Add(wifiBuilder.SetName("DEXP WFA-AC1 Combo")
            .SetStandartVersion("4 (802.11n)").SetPciVersion("PCI-E")
            .SetBluetooth(true).SetWattage(2).GetResult());

        wifiList.Add(wifiBuilder.SetName("MSI GUAX18")
            .SetStandartVersion("6 (802.11ax)").SetPciVersion("PCI-E")
            .SetBluetooth(false).SetWattage(5).GetResult());

        return wifiList;
    }

    public IList<WiFiAdapter> AddNewComponent(IList<WiFiAdapter> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<WiFiAdapter> updatedDb = BuildComponentDb();
        foreach (WiFiAdapter tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}