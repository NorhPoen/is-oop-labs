using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class GpuBuilder : IGpuBuilder
{
    private string? _name;
    private int _height;
    private int _width;
    private int _memory;
    private string? _pcie;
    private int _coreClock;
    private int _wattage;

    public IGpuBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IGpuBuilder SetHeight(int height)
    {
        _height = height;
        return this;
    }

    public IGpuBuilder SetWidth(int width)
    {
        _width = width;
        return this;
    }

    public IGpuBuilder SetMemory(int memory)
    {
        _memory = memory;
        return this;
    }

    public IGpuBuilder SetPcie(string pcie)
    {
        _pcie = pcie;
        return this;
    }

    public IGpuBuilder SetCoreClock(int coreClock)
    {
        _coreClock = coreClock;
        return this;
    }

    public IGpuBuilder SetWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public Gpu GetResult()
    {
        if (_name is not null && _pcie is not null)
        {
            return new Gpu(_name, _height, _width, _memory, _pcie, _coreClock, _wattage);
        }

        throw new ArgumentException("Field can't be null");
    }
}