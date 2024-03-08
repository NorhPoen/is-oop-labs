using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class CpuCoolerDB : IBuildComponentDb<CpuCooler>
{
    public IList<CpuCooler> BuildComponentDb()
    {
        var cpuCoolerList = new List<CpuCooler>();
        var cpuCoolerBuilder = new CpuCoolerBuilder();

        cpuCoolerList.Add(cpuCoolerBuilder.SetName("ID-COOLING SE-224-XTS")
            .SetSockets(new List<string>
                { "AM4", "AM5", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1156", "LGA 1200", "LGA 1700", })
            .SetFansSize(120).SetMaxTdp(220).GetResult());

        cpuCoolerList.Add(cpuCoolerBuilder.SetName("be quiet! DARK ROCK PRO 4")
            .SetSockets(new List<string>
                {
                    "AM2", "AM2+", "AM3", "AM3+", "AM4", "AM5", "FM1", "FM2", "FM2+",
                    "LGA 1150", "LGA 1151", "LGA 1151-v2", "LGA 1155", "LGA 1156", "LGA 1200",
                    "LGA 1366", "LGA 1700", "LGA 2011", "LGA 2011-3", "LGA 2066",
                })
            .SetFansSize(120).SetMaxTdp(250).GetResult());

        cpuCoolerList.Add(cpuCoolerBuilder.SetName("DEEPCOOL Gamma Archer")
            .SetSockets(new List<string>
                {
                    "AM2", "AM2+", "AM3", "AM3+", "AM4", "FM1", "FM2", "LGA 775",
                    "LGA 1150", "LGA 1151", "LGA 1151-v2", "LGA 1155", "LGA 1156", "LGA 1200",
                })
            .SetFansSize(120).SetMaxTdp(75).GetResult());

        return cpuCoolerList;
    }

    public IList<CpuCooler> AddNewComponent(IList<CpuCooler> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<CpuCooler> updatedDb = BuildComponentDb();
        foreach (CpuCooler tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}