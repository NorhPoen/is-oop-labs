using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : BaseObstacle
{
    public Asteroid(int numberObstacles)
    {
        if (numberObstacles < 0)
        {
            throw new ArgumentException("Number of asteroids can not be negative.");
        }

        Damage = BasicValues.AsteroidDamage;
        NumberOfObstacles = numberObstacles;
    }
}