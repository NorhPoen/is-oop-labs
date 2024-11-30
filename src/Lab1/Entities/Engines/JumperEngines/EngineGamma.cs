using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumperEngines;

public class EngineGamma : BaseEngine
{
    public EngineGamma()
    {
        MaxDistance = BasicValues.MaximalDistEngineGamma;
        JumpCost = BasicValues.FuelCostOneUnitEngineGamma;
        JumpTime = BasicValues.TimeTravelOneUnitEngineGamma;
    }

    public int JumpCost { get; set; }
    public int JumpTime { get; set; }

    public override double TravelTime(int distance)
    {
        return JumpTime;
    }

    public override double FuelCost(int distance)
    {
        return Math.Pow(distance, 2) * JumpCost;
    }
}