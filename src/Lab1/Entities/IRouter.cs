using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IRouter
{
    public void SimulateAdventures(
        IList<AdventureResult> results,
        IList<BaseShip> ships,
        IList<BaseEnvironment> spaces);

    public BaseShip? BestOfTwoShips(
        BaseShip ship1,
        BaseShip ship2,
        AdventureResult flyResult1,
        AdventureResult flyResult2);
}