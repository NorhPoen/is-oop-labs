using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class CpuDB : IBuildComponentDb<Cpu>
{
    public IList<Cpu> BuildComponentDb()
    {
        var cpuList = new List<Cpu>();
        var cpuBuilder = new CpuBuilder();

        cpuList.Add(cpuBuilder.SetName("Intel Core i7-11700F").SetClockSpeed(2500)
            .SetCores(8).SetSocket("LGA 1200").SetMaximumRamSpeed(3200).SetTdp(90).SetWattage(90).GetResult());

        cpuList.Add(cpuBuilder.SetName("Intel Core i5-13500").SetClockSpeed(2500)
            .SetCores(14).SetSocket("LGA 1700").SetMaximumRamSpeed(3200).SetTdp(65).SetWattage(70).SetIntegratedGraphics("Intel UHD Graphics 770").GetResult());

        cpuList.Add(cpuBuilder.SetName("AMD Ryzen 5 5600G").SetClockSpeed(3900)
            .SetCores(6).SetSocket("AM4").SetMaximumRamSpeed(3200).SetTdp(65).SetWattage(60).SetIntegratedGraphics("AMD Radeon Vega 7").GetResult());

        cpuList.Add(cpuBuilder.SetName("AMD Ryzen 5 7500F").SetClockSpeed(3700)
            .SetCores(6).SetSocket("AM5").SetMaximumRamSpeed(5200).SetTdp(65).SetWattage(75).GetResult());

        return cpuList;
    }

    public IList<Cpu> AddNewComponent(IList<Cpu> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<Cpu> updatedDb = BuildComponentDb();
        foreach (Cpu tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}