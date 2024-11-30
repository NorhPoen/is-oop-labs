using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class HddBuilder : IHddBuilder
{
    private string? _name;
    private int _capacity;
    private int _spindleSpeed;
    private int _wattage;

    public IHddBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder SetCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder SetSpindleSpeed(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHddBuilder SetWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public Hdd GetResult()
    {
        if (_name is not null)
        {
            return new Hdd(_name, _capacity, _spindleSpeed, _wattage);
        }

        throw new ArgumentException("Name can not be null");
    }
}