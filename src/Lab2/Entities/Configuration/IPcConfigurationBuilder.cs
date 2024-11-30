using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Configuration;

public interface IPcConfigurationBuilder
{
    IPcConfigurationBuilder WithMotherBoard(MotherBoard motherBoard);

    IPcConfigurationBuilder WithCpu(Cpu cpu);

    IPcConfigurationBuilder WithSsd(Ssd ssd);

    IPcConfigurationBuilder WithSsd(IList<Ssd> ssds);

    IPcConfigurationBuilder WithHdd(Hdd hdd);

    IPcConfigurationBuilder WithHdd(IList<Hdd> hdds);

    IPcConfigurationBuilder WithCorpus(CasePc casePc);

    IPcConfigurationBuilder WithCooler(CpuCooler cpuCooler);

    IPcConfigurationBuilder WithPowerBlock(PowerSupply powerSupply);

    IPcConfigurationBuilder WithGraphicCard(Gpu gpu);

    IPcConfigurationBuilder WithWiFiAdapter(WiFiAdapter wiFiAdapter);

    IPcConfigurationBuilder WithRam(Ram ram);

    IPcConfigurationBuilder WithRamStick(IList<Ram> rams);

    PcConfiguration Build();
}