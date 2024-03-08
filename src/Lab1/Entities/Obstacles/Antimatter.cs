using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Antimatter : BaseObstacle
{
    public Antimatter(int numberObstacles)
    {
        if (numberObstacles < 0)
        {
            throw new ArgumentException("Number of antimatter can not be negative.");
        }

        Damage = BasicValues.AnimatterDamage;
        NumberOfObstacles = numberObstacles;
    }
}