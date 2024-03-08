using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Space : BaseEnvironment
{
    public Space(int pathLength, int asteroidsCounter, int meteoritesCounter)
    {
        PathLength = pathLength;
        Obstacle = new Asteroid(asteroidsCounter);
        Obstacle2 = new Meteorite(meteoritesCounter);
    }
}
