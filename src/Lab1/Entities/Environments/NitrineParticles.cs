using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NitrineParticles : BaseEnvironment
{
    public NitrineParticles(int pathLength)
    {
        PathLength = pathLength;
    }

    public NitrineParticles(int pathLength, int obstacleCounter)
    {
        PathLength = pathLength;
        Obstacle = new SpaceWhale(obstacleCounter);
    }
}