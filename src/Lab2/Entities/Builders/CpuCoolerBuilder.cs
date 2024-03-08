using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class CpuCoolerBuilder : ICpuCoolerBuilder
{
    private string? _name;
    private IEnumerable<string>? _sockets;
    private int _fansSize;
    private int _maxTdp;

    public ICpuCoolerBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuCoolerBuilder SetSockets(IEnumerable<string> sockets)
    {
        _sockets = sockets;
        return this;
    }

    public ICpuCoolerBuilder SetFansSize(int fansSize)
    {
        _fansSize = fansSize;
        return this;
    }

    public ICpuCoolerBuilder SetMaxTdp(int maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public CpuCooler GetResult()
    {
        if (_name is not null && _sockets is not null)
        {
            return new CpuCooler(_name, _sockets, _fansSize, _maxTdp);
        }

        throw new ArgumentException("Field can't be null");
    }
}