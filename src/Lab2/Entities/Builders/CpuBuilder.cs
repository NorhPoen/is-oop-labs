using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CpuBuilder : ICpuBuilder
{
    private string? _name;
    private int _clockSpeed;
    private int _cores;
    private string? _socket;
    private string _integratedGraphics = string.Empty;
    private int _maximumRamSpeed;
    private int _tdp;
    private int _wattage;

    public ICpuBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder SetClockSpeed(int clockSpeed)
    {
        _clockSpeed = clockSpeed;
        return this;
    }

    public ICpuBuilder SetCores(int cores)
    {
        _cores = cores;
        return this;
    }

    public ICpuBuilder SetSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder SetIntegratedGraphics(string integratedGraphics)
    {
        _integratedGraphics = integratedGraphics;
        return this;
    }

    public ICpuBuilder SetMaximumRamSpeed(int maximumRamSpeed)
    {
        _maximumRamSpeed = maximumRamSpeed;
        return this;
    }

    public ICpuBuilder SetTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder SetWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public Cpu GetResult()
    {
        if (_name is not null && _socket is not null)
        {
            return new Cpu(_name, _clockSpeed, _cores, _socket, _integratedGraphics, _maximumRamSpeed, _tdp, _wattage);
        }

        throw new ArgumentException("Field can not be null");
    }
}