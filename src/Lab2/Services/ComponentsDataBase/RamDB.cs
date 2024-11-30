using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class RamDB : IBuildComponentDb<Ram>
{
    public IList<Ram> BuildComponentDb()
    {
        var ramList = new List<Ram>();
        var ramBuilder = new RamBuilder();

        ramList.Add(ramBuilder.SetName("Kingston FURY Beast Black").SetCapacity(8)
            .SetXmps(new List<string> { "3000, 15-17-17", "3200, 16-18-18", })
        .SetFormFactor("DIMM").SetDdrStandart("DDR4").SetWattage(2).GetResult());

        ramList.Add(ramBuilder.SetName("ADATA XPG Lancer").SetCapacity(16)
            .SetXmps(new List<string> { "5200, 38-38-38", })
            .SetFormFactor("DIMM").SetDdrStandart("DDR5").SetWattage(1).GetResult());

        ramList.Add(ramBuilder.SetName("Patriot Signature Line").SetCapacity(4)
            .SetXmps(new List<string> { "1333, 9-9-9-24", })
            .SetFormFactor("SO-DIMM").SetDdrStandart("DDR3").SetWattage(1).GetResult());

        return ramList;
    }

    public IList<Ram> AddNewComponent(IList<Ram> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<Ram> updatedDb = BuildComponentDb();
        foreach (Ram tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}