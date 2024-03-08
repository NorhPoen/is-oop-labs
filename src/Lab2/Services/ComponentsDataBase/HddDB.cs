using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class HddDB : IBuildComponentDb<Hdd>
{
    public IList<Hdd> BuildComponentDb()
    {
        var hddList = new List<Hdd>();
        var hddBuilder = new HddBuilder();

        hddList.Add(hddBuilder.SetName("WD Blue")
            .SetCapacity(1000).SetSpindleSpeed(7200).
            SetWattage(7).GetResult());

        hddList.Add(hddBuilder.SetName("Toshiba DT01")
            .SetCapacity(1000).SetSpindleSpeed(7200).
            SetWattage(7).GetResult());

        hddList.Add(hddBuilder.SetName("Seagate SkyHawk")
            .SetCapacity(4000).SetSpindleSpeed(5900).
            SetWattage(5).GetResult());

        return hddList;
    }

    public IList<Hdd> AddNewComponent(IList<Hdd> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<Hdd> updatedDb = BuildComponentDb();
        foreach (Hdd tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}