using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class XmpBuilder : IProfileXmpBuilder
{
    private string? _name;
    private int _voltage;
    private int _frequency;

    public IProfileXmpBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IProfileXmpBuilder SetVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IProfileXmpBuilder SetFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public ProfileXmp GetResult()
    {
        if (_name is not null)
        {
            return new ProfileXmp(_name, _voltage, _frequency);
        }

        throw new ArgumentNullException(_name);
    }
}