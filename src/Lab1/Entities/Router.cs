using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Router : IRouter
{
    public void SimulateAdventures(IList<AdventureResult> results, IList<BaseShip> ships, IList<BaseEnvironment> spaces)
    {
        ArgumentNullException.ThrowIfNull(ships);
        ArgumentNullException.ThrowIfNull(spaces);
        ArgumentNullException.ThrowIfNull(results);

        for (int i = 0; i < ships.Count; i++)
        {
            ArgumentNullException.ThrowIfNull(ships[i]);
            for (int j = 0; j < spaces.Count; j++)
            {
                if (!ships[i].CanFlySpace(spaces[j], results[i]))
                {
                    AdventureResult flyResult = results[i];
                    flyResult.ShipIsLost = true;
                    results[i] = flyResult;
                    break;
                }

                if (!ships[i].TryToDefendObstacles(spaces[j]))
                {
                    AdventureResult flyResult = results[i];
                    if (spaces[j] is not HighDensitySpace)
                    {
                        flyResult.ShipIsDestroyed = true;
                    }

                    flyResult.TeamIsDead = true;
                    results[i] = flyResult;
                    break;
                }

                if (spaces[j] is not HighDensitySpace)
                {
                    AdventureResult flyResult = results[i];
                    flyResult.FuelCost += ships[i].SummaryImpulsiveFuel(spaces[j].PathLength);
                    flyResult.TimeSpent += ships[i].ImpulsiveTime(spaces[j].PathLength);
                    results[i] = flyResult;
                }
                else
                {
                    AdventureResult flyResult = results[i];
                    flyResult.FuelCost += ships[i].SummaryJumpFuel(spaces[j].PathLength);
                    flyResult.TimeSpent += ships[i].JumpTime(spaces[j].PathLength);
                    results[i] = flyResult;
                }
            }

            if (!results[i].TeamIsDead && !results[i].ShipIsDestroyed && !results[i].ShipIsLost)
            {
                AdventureResult tmp = results[i];
                tmp.Success = true;
                results[i] = tmp;
            }
        }
    }

    public BaseShip? BestOfTwoShips(BaseShip ship1, BaseShip ship2, AdventureResult flyResult1, AdventureResult flyResult2)
    {
        if (flyResult1.Success && flyResult2.Success)
        {
            if (flyResult1.FuelCost < flyResult2.FuelCost)
            {
                return ship1;
            }

            if (flyResult1.FuelCost > flyResult2.FuelCost)
            {
                return ship2;
            }

            return flyResult1.TimeSpent < flyResult2.TimeSpent ? ship1 : ship2;
        }

        if (flyResult1.Success)
        {
            return ship1;
        }

        return flyResult2.Success ? ship2 : null;
    }
}