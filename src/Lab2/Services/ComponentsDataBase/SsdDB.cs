using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentsDataBase;

public class SsdDB : IBuildComponentDb<Ssd>
{
    public IList<Ssd> BuildComponentDb()
    {
        var ssdList = new List<Ssd>();
        var ssdBuilder = new SsdBuilder();

        ssdList.Add(ssdBuilder.SetName("Kingston A400").SetConnectionType("SATA").
            SetCapacity(480).SetReadSpeed(500).SetWriteSpeed(450).SetWattage(2).GetResult());

        ssdList.Add(ssdBuilder.SetName("Samsung 870 EVO").SetConnectionType("SATA").
            SetCapacity(1000).SetReadSpeed(560).SetWriteSpeed(530).SetWattage(4).GetResult());

        ssdList.Add(ssdBuilder.SetName("MSI SPATIUM M450").SetConnectionType("SATA").
            SetCapacity(1000).SetReadSpeed(3600).SetWriteSpeed(3000).SetWattage(4).GetResult());

        return ssdList;
    }

    public IList<Ssd> AddNewComponent(IList<Ssd> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<Ssd> updatedDb = BuildComponentDb();
        foreach (Ssd tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}