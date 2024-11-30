using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumperEngines;

public class EngineOmega : BaseEngine
{
    public EngineOmega()
    {
        MaxDistance = BasicValues.MaximalDistEngineOmega;
        JumpCost = BasicValues.FuelCostOneUnitEngineOmega;
        JumpTime = BasicValues.TimeTravelOneUnitEngineOmega;
    }

    public int JumpCost { get; set; }
    public int JumpTime { get; set; }

    public override double TravelTime(int distance)
    {
        return distance * JumpTime;
    }

    public override double FuelCost(int distance)
    {
        return distance * Math.Log(distance) * JumpCost;
    }
}