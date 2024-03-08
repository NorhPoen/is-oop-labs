namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumperEngines;

public class EngineAlpha : BaseEngine
{
    public EngineAlpha()
    {
        MaxDistance = BasicValues.MaximalDistEngineAlpha;
        JumpTime = BasicValues.TimeTravelOneUnitEngineAlpha;
        JumpCost = BasicValues.FuelCostOneUnitEngineAlpha;
    }

    public int JumpTime { get; set; }
    public int JumpCost { get; set; }

    public override double TravelTime(int distance)
    {
        return JumpTime;
    }

    public override double FuelCost(int distance)
    {
        return distance * JumpCost;
    }
}