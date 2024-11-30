using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ConfigSpecification;

public class BuilderSpecification : IBuilderSpecification
{
    private string? _cpu;
    private string? _casePc;
    private string? _cpuCooler;
    private string? _powerSupply;
    private string? _motherBoard;
    private string? _gpu;
    private string? _wiFiAdapter;
    private IList<string> _ram = new List<string>();
    private IList<string>? _ssd;
    private IList<string>? _hdd;

    public IBuilderSpecification WithMotherBoard(string motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IBuilderSpecification WithCpu(string cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IBuilderSpecification WithSsd(string ssd)
    {
        _ssd ??= new List<string>();
        _ssd.Add(ssd);
        return this;
    }

    public IBuilderSpecification WithSsd(IList<string> ssds)
    {
        ArgumentNullException.ThrowIfNull(ssds);
        _ssd ??= new List<string>();
        foreach (string tmp in ssds)
        {
            _ssd.Add(tmp);
        }

        return this;
    }

    public IBuilderSpecification WithHdd(string hdd)
    {
        _hdd ??= new List<string>();
        _hdd.Add(hdd);
        return this;
    }

    public IBuilderSpecification WithHdd(IList<string> hdds)
    {
        ArgumentNullException.ThrowIfNull(hdds);
        _hdd ??= new List<string>();
        foreach (string tmp in hdds)
        {
            _hdd.Add(tmp);
        }

        return this;
    }

    public IBuilderSpecification WithCorpus(string casePc)
    {
        _casePc = casePc;
        return this;
    }

    public IBuilderSpecification WithCooler(string cpuCooler)
    {
        _cpuCooler = cpuCooler;
        return this;
    }

    public IBuilderSpecification WithPowerBlock(string powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IBuilderSpecification WithGraphicCard(string gpu)
    {
        _gpu = gpu;
        return this;
    }

    public IBuilderSpecification WithWiFiAdapter(string wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public IBuilderSpecification WithRamStick(string ram)
    {
        _ram ??= new List<string>();
        _ram.Add(ram);
        return this;
    }

    public IBuilderSpecification WithRamStick(IList<string> rams)
    {
        ArgumentNullException.ThrowIfNull(rams);
        _ram ??= new List<string>();
        foreach (string tmp in rams)
        {
            _ram.Add(tmp);
        }

        return this;
    }

    public Specification Build()
    {
        if (string.IsNullOrEmpty(_motherBoard) || string.IsNullOrEmpty(_cpu) || string.IsNullOrEmpty(_cpuCooler) ||
            string.IsNullOrEmpty(_casePc) || string.IsNullOrEmpty(_powerSupply) || _ram.Count == 0 || (_ssd is null && _hdd is null))
        {
            throw new ArgumentException("Invalid data for PC specification.");
        }

        return new Specification(_cpu, _casePc, _cpuCooler, _powerSupply, _motherBoard, _gpu, _wiFiAdapter, _ram, _ssd, _hdd);
    }
}