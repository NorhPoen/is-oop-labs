using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Configuration;

public class PcConfigurationBuilder : IPcConfigurationBuilder
{
    private MotherBoard? _motherBoard;
    private Cpu? _cpu;
    private IList<Ssd>? _ssd;
    private IList<Hdd>? _hdd;
    private CasePc? _case;
    private PowerSupply? _powerSupply;
    private IList<Ram> _ram = new List<Ram>();
    private CpuCooler? _cpuCooler;
    private Gpu? _gpu;
    private WiFiAdapter? _wiFiAdapter;

    public IPcConfigurationBuilder WithMotherBoard(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IPcConfigurationBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPcConfigurationBuilder WithSsd(Ssd ssd)
    {
        _ssd ??= new List<Ssd>();
        _ssd.Add(ssd);
        return this;
    }

    public IPcConfigurationBuilder WithSsd(IList<Ssd> ssds)
    {
        _ssd ??= new List<Ssd>();

        ArgumentNullException.ThrowIfNull(ssds);
        foreach (Ssd tmp in ssds)
        {
            _ssd.Add(tmp);
        }

        return this;
    }

    public IPcConfigurationBuilder WithHdd(Hdd hdd)
    {
        _hdd ??= new List<Hdd>();
        _hdd.Add(hdd);

        return this;
    }

    public IPcConfigurationBuilder WithHdd(IList<Hdd> hdds)
    {
        _hdd ??= new List<Hdd>();

        ArgumentNullException.ThrowIfNull(hdds);
        foreach (Hdd tmp in hdds)
        {
            _hdd.Add(tmp);
        }

        return this;
    }

    public IPcConfigurationBuilder WithCorpus(CasePc casePc)
    {
        _case = casePc;
        return this;
    }

    public IPcConfigurationBuilder WithCooler(CpuCooler cpuCooler)
    {
        _cpuCooler = cpuCooler;
        return this;
    }

    public IPcConfigurationBuilder WithPowerBlock(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IPcConfigurationBuilder WithGraphicCard(Gpu gpu)
    {
        _gpu = gpu;
        return this;
    }

    public IPcConfigurationBuilder WithWiFiAdapter(WiFiAdapter wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public IPcConfigurationBuilder WithRam(Ram ram)
    {
        _ram.Add(ram);
        return this;
    }

    public IPcConfigurationBuilder WithRamStick(IList<Ram> rams)
    {
        ArgumentNullException.ThrowIfNull(rams);
        foreach (Ram tmp in rams)
        {
            _ram.Add(tmp);
        }

        return this;
    }

    public PcConfiguration Build()
    {
        if ((_ssd is null && _hdd is null) || _ram.Count == 0 || _motherBoard is null ||
            _cpu is null || _case is null || _powerSupply is null || _cpuCooler is null)
        {
            throw new ArgumentException("Invalid data for PC configuration.");
        }

        return new PcConfiguration(_motherBoard, _cpu, _ssd, _hdd, _case, _powerSupply, _ram, _cpuCooler, _gpu, _wiFiAdapter);
    }
}