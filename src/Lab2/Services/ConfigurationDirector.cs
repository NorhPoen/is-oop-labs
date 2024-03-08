using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ConfigSpecification;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Configuration;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ConfigurationChecker;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ConfigurationDirector
{
    private Specification _specificator;
    private bool _guarantee = true;
    private string? _comment;

    private ComputerFactory _computerComponentsFactory = new ComputerFactory(
        new CpuFactory(),
        new MotherBoardFactory(),
        new RamFactory(),
        new CpuCoolerFactory(),
        new CasePcFactory(),
        new GpuFactory(),
        new HddFactory(),
        new SsdFactory(),
        new PowerSupplyFactory(),
        new WiFiAdapterFactory());
    public ConfigurationDirector(Specification specificator)
    {
        _specificator = specificator;
    }

    public ConfigurationDirector(Specification specificator, ComputerFactory computerComponentsFactory)
    {
        _specificator = specificator;
        _computerComponentsFactory = computerComponentsFactory;
    }

    public ConfigurationBuildResult Build()
    {
        var builder = new PcConfigurationBuilder();
        var checker = new ConfigurationValidity();
        int power = 0;
        CasePc? corpus = _computerComponentsFactory.CreateCorpusByName(_specificator.CasePc);
        if (corpus is null)
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this corpus name");
        }

        builder.WithCorpus(corpus);
        PowerSupply? powerBlock = _computerComponentsFactory.CreatePowerBlockByName(_specificator.PowerSupply);
        if (powerBlock is null)
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this power block name");
        }

        builder.WithPowerBlock(powerBlock);

        MotherBoard? motherBoard = _computerComponentsFactory.CreateMotherBoardByName(_specificator.MotherBoard);
        if (motherBoard is null)
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this motherboard name");
        }

        if (!checker.CompatibilityCorpusAndMotherBoard(motherBoard, corpus))
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this motherboard and this corpus");
        }

        builder.WithMotherBoard(motherBoard);

        Cpu? cpu = _computerComponentsFactory.CreateCpuByName(_specificator.Cpu);
        if (cpu is null)
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this cpu name");
        }

        if (!checker.CompatibilityMotherBoardAndCpu(motherBoard, cpu))
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this motherboard and this cpu");
        }

        builder.WithCpu(cpu);
        power += cpu.Wattage;
        IList<Ram> ramSticks = new List<Ram>();
        int numberSticks = 0;
        foreach (string ramStickName in _specificator.Ram)
        {
            Ram? ramStick = _computerComponentsFactory.CreateRamStickByName(ramStickName);
            if (ramStick is null)
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this RAM name");
            }

            numberSticks++;

            if (numberSticks > motherBoard.DdrSlots)
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this number ram stick and this motherboard");
            }

            if (!checker.CompatibilityRamAndMotherBoard(motherBoard, ramStick))
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this ram stick and this motherboard");
            }

            ramSticks.Add(ramStick);

            builder.WithRam(ramStick);
            power += ramStick.Wattage;
        }

        if (_specificator.Ssd is null && _specificator.Hdd is null)
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer without a ssd or hdd");
        }

        int sataPorts = 0;
        if (_specificator.Ssd is not null)
        {
            foreach (string ssdName in _specificator.Ssd)
            {
                Ssd? ssd = _computerComponentsFactory.CreateSsdByName(ssdName);
                if (ssd is null)
                {
                    return new ConfigurationBuildResult(null, false, "You can't make a computer with this SSD name");
                }

                if (!checker.CompatibilityMotherBoardAndSsd(motherBoard, ssd))
                {
                    if (sataPorts + 1 <= motherBoard.SlotsSata)
                    {
                        sataPorts++;
                    }
                    else
                    {
                        return new ConfigurationBuildResult(null, false, "You can't make a computer with this motherboard and this ssd");
                    }
                }

                builder.WithSsd(ssd);
                power += ssd.Wattage;
            }
        }

        if (_specificator.Hdd is not null)
        {
            foreach (string hddName in _specificator.Hdd)
            {
                Hdd? hdd = _computerComponentsFactory.CreateHddByName(hddName);
                if (hdd is null || sataPorts + 1 > motherBoard.SlotsSata)
                {
                    return new ConfigurationBuildResult(null, false, "You can't make a computer with this HDD name");
                }

                sataPorts++;
                builder.WithHdd(hdd);
                power += hdd.Wattage;
            }
        }

        CpuCooler? cooler = _computerComponentsFactory.CreateCoolerByName(_specificator.CpuCooler);
        if (cooler is null)
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this cooler name");
        }

        if (!checker.CompatibilityCoolerAndCorpus(cooler, corpus))
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this cooler and this corpus");
        }

        if (!checker.CompatibilityMotherBoardAndCooler(motherBoard, cooler))
        {
            return new ConfigurationBuildResult(null, false, "You can't make a computer with this cooler and this motherborad");
        }

        if (!checker.CompatibilityCoolerAndCpu(cpu, cooler))
        {
            _guarantee = false;
            _comment = "It is recommended to put a cooler with a large TDP";
        }

        builder.WithCooler(cooler);

        if (!string.IsNullOrEmpty(_specificator.WiFiAdapter))
        {
            WiFiAdapter? wiFiAdapter = _computerComponentsFactory.CreateWiFiAdapterByName(_specificator.WiFiAdapter);
            if (wiFiAdapter is null)
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this WiFi adapter name");
            }

            if (!checker.CompatibilityMotherBoardAndWiFiAdapter(motherBoard, wiFiAdapter))
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this motherboard and this WiFi adapter");
            }

            builder.WithWiFiAdapter(wiFiAdapter);
        }

        if (!string.IsNullOrEmpty(_specificator.Gpu))
        {
            Gpu? graphicCard = _computerComponentsFactory.CreateGraphicCardByName(_specificator.Gpu);
            if (graphicCard is null)
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this graphic card name");
            }

            if (!checker.CompatibilityMotherBoardAndGraphicCard(motherBoard, graphicCard))
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this motherboard and this graphic card");
            }

            if (!checker.CompatibilityGraphicCardAndCorpus(graphicCard, corpus))
            {
                return new ConfigurationBuildResult(null, false, "You can't make a computer with this graphic card and this corpus");
            }

            builder.WithGraphicCard(graphicCard);
            power += graphicCard.Wattage;
        }

        if (!(powerBlock.MaxWattage >= power))
        {
            _guarantee = false;
            _comment += "Under load, the power supply may not be enough, there is no guarantee";
            if (!(powerBlock.MaxWattage >= power * 0.9))
            {
                return new ConfigurationBuildResult(null, false, "The power supply cannot power the system");
            }
        }

        return new ConfigurationBuildResult(builder.Build(), _guarantee, _comment);
    }
}