using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder SetName(string name);
    IWiFiAdapterBuilder SetStandartVersion(string standartVersion);
    IWiFiAdapterBuilder SetBluetooth(bool bluetooth);
    IWiFiAdapterBuilder SetPciVersion(string pciVersion);
    IWiFiAdapterBuilder SetWattage(int wattage);
    WiFiAdapter GetResult();
}