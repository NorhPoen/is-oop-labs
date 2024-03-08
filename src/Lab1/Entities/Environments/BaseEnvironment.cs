using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class BaseEnvironment
{
    public int PathLength { get; set; }
    public BaseObstacle? Obstacle { get; set; }
    public BaseObstacle? Obstacle2 { get; set; }
}