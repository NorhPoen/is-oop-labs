using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AdventureTest
{
    [Theory]
    [InlineData(15, 0)]
    public void ShouldReturnFalseForBoth(int distance, int counterObstacles)
    {
        var shipList = new List<BaseShip>() { new Shuttle(), new Augur() };

        var spaceList = new List<BaseEnvironment>() { new HighDensitySpace(distance, counterObstacles) };

        var results = new List<AdventureResult>() { new AdventureResult(false), new AdventureResult(false) };

        var router = new Router();

        router.SimulateAdventures(results, shipList, spaceList);

        Assert.True(results[0].ShipIsLost);
        Assert.True(results[1].ShipIsLost);
    }

    [Theory]
    [InlineData(7, 3)]
    public void ShouldReturnCrewIsNotAlvieAndPass(int distance, int counterObstacles)
    {
        var ships = new List<BaseShip>() { new Augur(), new Augur(true) };

        var spaces = new List<BaseEnvironment>() { new HighDensitySpace(distance, counterObstacles) };

        var results = new List<AdventureResult>() { new AdventureResult(false), new AdventureResult(false) };

        var router = new Router();

        router.SimulateAdventures(results, ships, spaces);

        Assert.True(results[0].TeamIsDead);
        Assert.True(results[1].Success);
    }

    [Theory]
    [InlineData(15, 1)]
    public void ShouldReturnShipIsNotAliveAndDeflectorIsNotAliveAndPass(int distance, int counterObstacles)
    {
        var ships = new List<BaseShip>() { new Vakhlas(), new Augur(), new Meredian() };

        var spaces = new List<BaseEnvironment>() { new NitrineParticles(distance, counterObstacles) };

        var results = new List<AdventureResult>() { new AdventureResult(false), new AdventureResult(false), new AdventureResult(false) };

        var router = new Router();

        router.SimulateAdventures(results, ships, spaces);

        Assert.True(results[0].ShipIsDestroyed);
        Assert.False(results[1].ShipIsDestroyed);
        Assert.False(results[2].ShipIsDestroyed);
    }

    [Theory]
    [InlineData(5, 0, 0)]
    public void ShouldReturnWalkingShuttleWinner(int distance, int nAsteroids, int kMeteorites)
    {
        var ships = new List<BaseShip>() { new Shuttle(), new Vakhlas() };

        var spaces = new List<BaseEnvironment>() { new Space(distance, nAsteroids, kMeteorites) };

        var results = new List<AdventureResult>() { new AdventureResult(false), new AdventureResult(false) };

        var router = new Router();

        router.SimulateAdventures(results, ships, spaces);

        BaseShip? winner = router.BestOfTwoShips(ships[0], ships[1], results[0], results[1]);
        Assert.Equal(ships[0], winner);
    }

    [Theory]
    [InlineData(11, 0)]
    public void ShouldReturnStellaWinner(int distance, int counterObstalces)
    {
        // ARRANGE
        var ships = new List<BaseShip>() { new Augur(), new Stella() };

        var spaces = new List<BaseEnvironment>() { new HighDensitySpace(distance, counterObstalces) };

        var flyres = new List<AdventureResult>() { new AdventureResult(false), new AdventureResult(false) };

        var navigator = new Router();

        // ACT
        navigator.SimulateAdventures(flyres, ships, spaces);
        BaseShip? winner = navigator.BestOfTwoShips(ships[0], ships[1], flyres[0], flyres[1]);

        // ASSERT
        Assert.Equal(winner, ships[1]);
    }

    [Theory]
    [InlineData(5, 1)]
    public void ShouldReturnVaclassWinner(int distance, int nWhalse)
    {
        // ARRANGE
        var ships = new List<BaseShip>() { new Shuttle(), new Augur() };

        var spaces = new List<BaseEnvironment>() { new NitrineParticles(distance, nWhalse) };

        var flyres = new List<AdventureResult>() { new AdventureResult(false), new AdventureResult(false) };

        var navigator = new Router();

        // ACT
        navigator.SimulateAdventures(flyres, ships, spaces);
        BaseShip? winner = navigator.BestOfTwoShips(ships[0], ships[1], flyres[0], flyres[1]);

        // ACT
        Assert.Equal(winner, ships[1]);
    }

    [Theory]
    [InlineData(4, 5, 6, 2, 3, 4, 2)]
    public void ShouldReturnMeredianWinner(int distance1, int distance2, int distance3, int nAsteroids, int kMeteorites, int zAntinitrineFlares, int nWhales)
    {
        var ships = new List<BaseShip>()
            { new Vakhlas(), new Meredian(true), new Stella(true) };

        var spaces = new List<BaseEnvironment>
        {
            new Space(distance1, nAsteroids, kMeteorites), new HighDensitySpace(distance2, zAntinitrineFlares),
            new NitrineParticles(distance3, nWhales),
        };

        var flyres = new List<AdventureResult>() { new AdventureResult(false), new AdventureResult(false), new AdventureResult(false) };

        var navigator = new Router();

        navigator.SimulateAdventures(flyres, ships, spaces);

        Assert.NotNull(ships[0]);
        Assert.NotNull(ships[1]);
        Assert.True(flyres[1].Success);
        Assert.False(flyres[0].Success);
        Assert.False(flyres[2].Success);
    }
}