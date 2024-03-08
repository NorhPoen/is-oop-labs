using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : BaseObstacle
{
    public Meteorite(int numberObstacles)
    {
        if (numberObstacles < 0)
        {
            throw new ArgumentException("Number of meteorites can not be negative.");
        }

        Damage = BasicValues.MeteoriteDamage;
        NumberOfObstacles = numberObstacles;
    }
}