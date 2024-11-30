using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ConfigurationChecker;

public class ConfigurationValidity : IConfigurationValidity
{
    public bool CompatibilityMotherBoardAndCpu(MotherBoard motherBoard, Cpu cpu)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(cpu);

        return motherBoard.Bios.SupportedCpu.Contains(cpu.Name) &&
               string.Equals(motherBoard.SocketCpu, cpu.Socket, StringComparison.Ordinal);
    }

    public bool CompatibilityCorpusAndMotherBoard(MotherBoard motherBoard, CasePc casePc)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(casePc);

        return casePc.FormFactors.Contains(motherBoard.FormFactor);
    }

    public bool CompatibilityMotherBoardAndSsd(MotherBoard motherBoard, Ssd ssd)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(ssd);

        switch (ssd.ConnectionType)
        {
            case "Sata":
                motherBoard.SlotsSata--;
                break;
            case "PCI":
                motherBoard.PcieLines--;
                break;
        }

        return motherBoard is { PcieLines: >= 0, SlotsSata: >= 0 };
    }

    public bool CompatibilityMotherBoardAndGraphicCard(MotherBoard motherBoard, Gpu gpu)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(gpu);
        motherBoard.PcieLines--;

        return motherBoard is { PcieLines: >= 0, SlotsSata: >= 0 };
    }

    public bool CompatibilityMotherBoardAndCooler(MotherBoard motherBoard, CpuCooler cooler)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(cooler);

        return cooler.Sockets.Contains(motherBoard.SocketCpu);
    }

    public bool CompatibilityCoolerAndCorpus(CpuCooler cooler, CasePc casePc)
    {
        ArgumentNullException.ThrowIfNull(cooler);
        ArgumentNullException.ThrowIfNull(casePc);

        return cooler.FansSize < casePc.Wight;
    }

    public bool CompatibilityRamAndMotherBoard(MotherBoard motherBoard, Ram ram)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(ram);

        return string.Equals(ram.DdrStandart, motherBoard.DdrStandard, StringComparison.Ordinal)
               && string.Equals(ram.FormFactor, motherBoard.RamFormFactor, StringComparison.Ordinal);
    }

    public bool CompatibilityMotherBoardAndWiFiAdapter(MotherBoard motherBoard, WiFiAdapter wiFiAdapter)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(wiFiAdapter);
        motherBoard.PcieLines--;

        return motherBoard is { PcieLines: >= 0, SlotsSata: >= 0 };
    }

    public bool CompatibilityGraphicCardAndCorpus(Gpu gpu, CasePc casePc)
    {
        ArgumentNullException.ThrowIfNull(gpu);
        ArgumentNullException.ThrowIfNull(casePc);

        return (gpu.Width <= casePc.GpuMaxWidth) && (gpu.Height <= casePc.GpuMaxHeight);
    }

    public bool CompatibilityPowerBlock(PowerSupply powerSupply, int summaryPower)
    {
        ArgumentNullException.ThrowIfNull(powerSupply);
        return powerSupply.MaxWattage >= summaryPower;
    }

    public bool CompatibilityPowerBlockSlightExcess(PowerSupply powerSupply, int summaryPower)
    {
        ArgumentNullException.ThrowIfNull(powerSupply);
        return powerSupply.MaxWattage >= summaryPower * 0.9;
    }

    public bool CompatibilityCoolerAndCpu(Cpu cpu, CpuCooler cooler)
    {
        ArgumentNullException.ThrowIfNull(cpu);
        ArgumentNullException.ThrowIfNull(cooler);

        return cooler.MaxTdp >= cpu.Tdp;
    }
}