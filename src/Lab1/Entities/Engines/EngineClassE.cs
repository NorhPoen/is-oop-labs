using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassE : BaseEngine
{
    public EngineClassE()
    {
        FuelConsumption = BasicValues.FuelConsumptionClassE;
        StartCost = BasicValues.StartCostClassE;
    }

    public int StartCost { get; }

    public override double TravelTime(int distance)
    {
        return Math.Log(distance + 1);
    }

    public override double FuelCost(int distance)
    {
        return StartCost + (TravelTime(distance) * FuelConsumption);
    }
}