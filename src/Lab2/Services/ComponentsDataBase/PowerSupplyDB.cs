using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class PowerSupplyDB : IBuildComponentDb<PowerSupply>
{
    public IList<PowerSupply> BuildComponentDb()
    {
        var powerSupplyList = new List<PowerSupply>();
        var powerSupplyBuilder = new PowerSupplyBuilder();

        powerSupplyList.Add(powerSupplyBuilder.SetName("DEEPCOOL PF600").
            SetMaxWattage(600).GetResult());

        powerSupplyList.Add(powerSupplyBuilder.SetName("Chieftec POLARIS 1050W").
            SetMaxWattage(1050).GetResult());

        powerSupplyList.Add(powerSupplyBuilder.SetName("be quiet! SYSTEM POWER 10 750W").
            SetMaxWattage(750).GetResult());

        powerSupplyList.Add(powerSupplyBuilder.SetName("Corsair RM650x").
            SetMaxWattage(409).GetResult());

        powerSupplyList.Add(powerSupplyBuilder.SetName("Cooler Master MWE 450 WHITE - V2").
            SetMaxWattage(450).GetResult());

        return powerSupplyList;
    }

    public IList<PowerSupply> AddNewComponent(IList<PowerSupply> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<PowerSupply> updatedDb = BuildComponentDb();
        foreach (PowerSupply tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}