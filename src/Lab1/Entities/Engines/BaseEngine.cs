namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class BaseEngine
{
    public int FuelConsumption { get; init; }
    public int? MaxDistance { get; init; }
    public abstract double FuelCost(int distance);
    public abstract double TravelTime(int distance);
}