namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassC : BaseEngine
{
    public EngineClassC()
    {
        FuelConsumption = BasicValues.FuelConsumptionClassC;
        Speed = BasicValues.SpeedClassC;
        StartCost = BasicValues.StartCostClassC;
    }

    public int Speed { get; }
    public int StartCost { get; }

    public override double TravelTime(int distance)
    {
        return distance / Speed;
    }

    public override double FuelCost(int distance)
    {
        return StartCost + (TravelTime(distance) * FuelConsumption);
    }
}