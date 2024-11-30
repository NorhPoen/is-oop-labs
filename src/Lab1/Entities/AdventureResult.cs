namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public record struct AdventureResult(
    bool Success = false,
    bool TeamIsDead = false,
    bool ShipIsDestroyed = false,
    bool ShipIsLost = false,
    double TimeSpent = 0,
    double FuelCost = 0);
