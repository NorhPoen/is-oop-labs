using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class BiosBuilder : IBiosBuilder
{
    private string? _name;
    private string? _biosType;
    private string? _biosVersion;
    private IList<string>? _supportedCpu;

    public IBiosBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IBiosBuilder SetBiosType(string biosType)
    {
        _biosType = biosType;
        return this;
    }

    public IBiosBuilder SetBiosVersion(string biosVersion)
    {
        _biosVersion = biosVersion;
        return this;
    }

    public IBiosBuilder SetSupportedCpu(IList<string> supportedCpu)
    {
        _supportedCpu = supportedCpu;
        return this;
    }

    public Bios GetResult()
    {
        if (_name is not null
            && _biosType is not null
            && _biosVersion is not null
            && _supportedCpu is not null)
        {
            return new Bios(_name, _biosType, _biosVersion, _supportedCpu);
        }

        throw new ArgumentException("Field is null");
    }
}
