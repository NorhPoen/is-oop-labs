using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhale : BaseObstacle
{
    public SpaceWhale(int numberObstacles)
    {
        if (numberObstacles < 0)
        {
            throw new ArgumentException("Number of whales can not be negative.");
        }

        Damage = BasicValues.SpaceWhaleDamage;
        NumberOfObstacles = numberObstacles;
    }
}