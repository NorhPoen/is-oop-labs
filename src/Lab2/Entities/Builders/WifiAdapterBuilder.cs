using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class WifiAdapterBuilder : IWiFiAdapterBuilder
{
    private string? _name;
    private string? _standartVersion;
    private bool _bluetooth;
    private string? _pciVersion;
    private int _wattage;

    public IWiFiAdapterBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IWiFiAdapterBuilder SetStandartVersion(string standartVersion)
    {
        _standartVersion = standartVersion;
        return this;
    }

    public IWiFiAdapterBuilder SetBluetooth(bool bluetooth)
    {
        _bluetooth = bluetooth;
        return this;
    }

    public IWiFiAdapterBuilder SetPciVersion(string pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IWiFiAdapterBuilder SetWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public WiFiAdapter GetResult()
    {
        if (_name is not null && _standartVersion is not null && _pciVersion is not null)
        {
            return new WiFiAdapter(_name, _standartVersion, _bluetooth, _pciVersion, _wattage);
        }

        throw new ArgumentException("Field can't be null");
    }
}