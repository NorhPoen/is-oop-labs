using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class SsdBuilder : ISsdBuilder
{
    private string? _name;
    private string? _connectionType;
    private int _capacity;
    private int _readSpeed;
    private int _writeSpeed;
    private int _wattage;

    public ISsdBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ISsdBuilder SetConnectionType(string connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public ISsdBuilder SetCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder SetReadSpeed(int readSpeed)
    {
        _readSpeed = readSpeed;
        return this;
    }

    public ISsdBuilder SetWriteSpeed(int writeSpeed)
    {
        _writeSpeed = writeSpeed;
        return this;
    }

    public ISsdBuilder SetWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public Ssd GetResult()
    {
        if (_name is not null && _connectionType is not null)
        {
            return new Ssd(_name, _connectionType, _capacity, _readSpeed, _writeSpeed, _wattage);
        }

        throw new ArgumentException("Field can't be null");
    }
}