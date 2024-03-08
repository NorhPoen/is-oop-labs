using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private string? _name;
    private int _maxWattage;

    public IPowerSupplyBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IPowerSupplyBuilder SetMaxWattage(int maxWattage)
    {
        _maxWattage = maxWattage;
        return this;
    }

    public PowerSupply GetResult()
    {
        if (_name is not null)
        {
            return new PowerSupply(_name, _maxWattage);
        }

        throw new ArgumentException("Field can't be null");
    }
}