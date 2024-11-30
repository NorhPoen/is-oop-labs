using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

public abstract class BaseHull
{
    protected BaseHull() { }

    protected BaseHull(int hitPoints)
    {
        if (hitPoints < 0)
        {
            throw new ArgumentException("Ship health points can't be negative.");
        }

        HitPoints = hitPoints;
    }

    public bool IsAlive => this.HitPoints > 0;

    public int HitPoints { get; set; }

    public bool TakeDamage(BaseObstacle obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        while ((HitPoints - obstacle.Damage >= 0) && obstacle.NumberOfObstacles != 0)
        {
            HitPoints -= obstacle.Damage;
            obstacle.NumberOfObstacles--;
        }

        return IsAlive;
    }
}