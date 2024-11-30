using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class GpuDB : IBuildComponentDb<Gpu>
{
    public IList<Gpu> BuildComponentDb()
    {
        var gpuList = new List<Gpu>();
        var gpuBuilder = new GpuBuilder();

        gpuList.Add(gpuBuilder.SetName("MSI GeForce RTX 4090 VENTUS 3X OC").SetHeight(62).SetWidth(136)
            .SetMemory(24).SetPcie("PCI-E x16").SetCoreClock(2230).SetWattage(450).GetResult());

        gpuList.Add(gpuBuilder.SetName("Gigabyte GeForce GTX 1080 Ti AORUS XTREME").SetHeight(55).SetWidth(124)
            .SetMemory(11).SetPcie("PCI-E x16").SetCoreClock(1607).SetWattage(350).GetResult());

        gpuList.Add(gpuBuilder.SetName("Sapphire AMD Radeon RX 550 PULSE").SetHeight(28).SetWidth(112)
            .SetMemory(4).SetPcie("PCI-E x16").SetCoreClock(1100).SetWattage(65).GetResult());

        gpuList.Add(gpuBuilder.SetName("\nSapphire AMD Radeon RX 7900 XTX PULSE").SetHeight(52).SetWidth(133)
            .SetMemory(24).SetPcie("PCI-E x16").SetCoreClock(1900).SetWattage(370).GetResult());

        return gpuList;
    }

    public IList<Gpu> AddNewComponent(IList<Gpu> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<Gpu> updatedDb = BuildComponentDb();
        foreach (Gpu tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}