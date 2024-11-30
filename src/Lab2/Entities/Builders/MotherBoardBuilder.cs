using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private string? _name;
    private string? _socketCpu;
    private int _pcieLines;
    private int _slotsSata;
    private string? _chipset;
    private string? _ddrStandard;
    private int _ddrSlots;
    private string? _formFactor;
    private string? _ramFormFactor;
    private Bios? _bios;
    public IMotherBoardBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherBoardBuilder SetSocketCpu(string socketCpu)
    {
        _socketCpu = socketCpu;
        return this;
    }

    public IMotherBoardBuilder SetPcieLines(int pcieLines)
    {
        _pcieLines = pcieLines;
        return this;
    }

    public IMotherBoardBuilder SetSlotsSata(int slotsSata)
    {
        _slotsSata = slotsSata;
        return this;
    }

    public IMotherBoardBuilder SetChipset(string chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherBoardBuilder SetDdrStandard(string ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IMotherBoardBuilder SetDdrSlots(int ddrSlots)
    {
        _ddrSlots = ddrSlots;
        return this;
    }

    public IMotherBoardBuilder SetFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder SetRamFormFactor(string ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IMotherBoardBuilder SetBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public MotherBoard GetResult()
    {
        if (_name is not null && _bios is not null
            && _socketCpu is not null && _chipset is not null
            && _ddrStandard is not null && _formFactor is not null && _ramFormFactor is not null)
        {
            return new MotherBoard(_name, _socketCpu, _pcieLines, _slotsSata, _chipset, _ddrStandard, _ddrSlots, _formFactor, _ramFormFactor, _bios);
        }

        throw new ArgumentException("Field can't be null");
    }
}