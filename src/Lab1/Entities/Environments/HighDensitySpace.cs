using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class HighDensitySpace : BaseEnvironment
{
    public HighDensitySpace(int pathLength)
    {
        PathLength = pathLength;
    }

    public HighDensitySpace(int pathLength, int obstacleCounter)
    {
        PathLength = pathLength;
        Obstacle = new Antimatter(obstacleCounter);
    }
}