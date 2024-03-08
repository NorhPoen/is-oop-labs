using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class RamBuilder : IRamBuilder
{
    private string? _name;
    private int _capacity;
    private int _frequency;
    private IEnumerable<string>? _xmps;
    private string? _formFactor;
    private string? _ddrStandart;
    private int _wattage;

    public IRamBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IRamBuilder SetCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IRamBuilder SetFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IRamBuilder SetXmps(IEnumerable<string> xmps)
    {
        _xmps = xmps;
        return this;
    }

    public IRamBuilder SetFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder SetDdrStandart(string ddrStandart)
    {
        _ddrStandart = ddrStandart;
        return this;
    }

    public IRamBuilder SetWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public Ram GetResult()
    {
        if (_name is not null && _xmps is not null
                              && _formFactor is not null && _ddrStandart is not null)
        {
            return new Ram(_name, _capacity, _frequency, _xmps, _formFactor, _ddrStandart, _wattage);
        }

        throw new ArgumentException("Field cannot be null");
    }
}