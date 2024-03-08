using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class WiFiAdapter : IPrototype<WiFiAdapter>
{
    public WiFiAdapter(
        string name,
        string standartVersion,
        bool bluetooth,
        string pciVersion,
        int wattage)
    {
        Name = name;
        StandartVersion = standartVersion ?? throw new ArgumentNullException(nameof(standartVersion));
        Bluetooth = bluetooth;
        PciVersion = pciVersion;
        Wattage = wattage;
    }

    public string Name { get; set; }
    public string StandartVersion { get; init; }
    public bool Bluetooth { get; init; }
    public string PciVersion { get; init; }
    public int Wattage { get; init; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(Name, StandartVersion, Bluetooth, PciVersion, Wattage);
    }
}