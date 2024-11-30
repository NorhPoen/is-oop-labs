using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class BaseShip
{
    protected BaseShip(bool thereIsPhotinicDefl)
    {
        if (thereIsPhotinicDefl)
        {
            PhotonicDeflector = new PhotonicDeflector();
        }
    }

    protected BaseEngine? JumpEngine { get; init; }
    protected BaseEngine? ImpulsiveEngine { get; init; }
    protected BaseHull? Hull { get; init; }
    protected BaseDeflector? Deflector { get; init; }
    protected PhotonicDeflector? PhotonicDeflector { get; init; }
    protected int Dimensions { get; init; }
    protected bool AntinitrineEmitter { get; init; }

    public double SummaryImpulsiveFuel(int distance)
    {
        if (ImpulsiveEngine is null)
        {
            throw new ArgumentException("Impulsive Engine is null!");
        }

        return Dimensions * ImpulsiveEngine.FuelCost(distance) * BasicValues.ImpulsiveFuelPrice;
    }

    public double ImpulsiveTime(int distance)
    {
        if (ImpulsiveEngine is null)
        {
            throw new ArgumentException("Impulsive Engine is Null!");
        }

        return ImpulsiveEngine.TravelTime(distance);
    }

    public double SummaryJumpFuel(int distance)
    {
        if (JumpEngine is not null)
        {
            return Dimensions * JumpEngine.FuelCost(distance) * BasicValues.JumpEnginePrice;
        }

        return 0;
    }

    public double JumpTime(int distance)
    {
        if (JumpEngine is not null)
        {
            return JumpEngine.TravelTime(distance);
        }

        return 0;
    }

    public bool TryToDefendObstacles(BaseEnvironment spaceBase)
    {
        ArgumentNullException.ThrowIfNull(spaceBase);
        switch (spaceBase)
        {
            case Space when spaceBase.Obstacle is null:
                throw new ArgumentException("There is no asteroids!");
            case Space when spaceBase.Obstacle2 is null:
                throw new AggregateException("There is no meteorites");
            case Space:
            {
                int num1 = spaceBase.Obstacle.NumberOfObstacles;
                int num2 = spaceBase.Obstacle2.NumberOfObstacles;

                if (Deflector is not null && Deflector.IsAlive)
                {
                    if (Deflector.TakeDamage(new Asteroid(num1))
                        && Deflector.TakeDamage(new Meteorite(num2)))
                    {
                        return true;
                    }
                }

                if (Hull is null)
                {
                    throw new ArgumentException("Carcass is Null!");
                }

                return Hull.TakeDamage(new Asteroid(num1))
                       && Hull.TakeDamage(new Meteorite(num2));
            }

            case HighDensitySpace when spaceBase.Obstacle is null:
                throw new ArgumentException("Obstacle is null!");
            case HighDensitySpace when spaceBase.Obstacle.NumberOfObstacles == 0:
                return true;
            case HighDensitySpace when PhotonicDeflector is null || !PhotonicDeflector.IsAlive:
                return false;
            case HighDensitySpace:
                PhotonicDeflector.TakeDamage(new Antimatter(1));
                return true;
        }

        if (spaceBase is NitrineParticles)
        {
            ArgumentNullException.ThrowIfNull(spaceBase.Obstacle);

            if (AntinitrineEmitter)
            {
                return true;
            }

            int n = spaceBase.Obstacle.NumberOfObstacles;
            ArgumentNullException.ThrowIfNull(Deflector);

            return Deflector is DeflectorClass3 && Deflector.IsAlive && n < 2;
        }

        throw new ArgumentException("No such space type!");
    }

    public bool CanFlySpace(BaseEnvironment space, AdventureResult result)
    {
        if (result.TeamIsDead)
        {
            return false;
        }

        if (space is Space)
        {
            return true;
        }

        if (space is HighDensitySpace)
        {
            if (JumpEngine is not null)
            {
                if (JumpEngine.MaxDistance >= space.PathLength)
                {
                    return true;
                }

                return false;
            }
        }

        if (ImpulsiveEngine is EngineClassE)
        {
            return true;
        }

        return false;
    }
}