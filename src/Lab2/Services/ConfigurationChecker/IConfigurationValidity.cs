using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ConfigurationChecker;

public interface IConfigurationValidity
{
    bool CompatibilityMotherBoardAndCpu(MotherBoard motherBoard, Cpu cpu);

    bool CompatibilityCorpusAndMotherBoard(MotherBoard motherBoard, CasePc casePc);

    bool CompatibilityMotherBoardAndSsd(MotherBoard motherBoard, Ssd ssd);

    bool CompatibilityMotherBoardAndGraphicCard(MotherBoard motherBoard, Gpu gpu);

    bool CompatibilityMotherBoardAndCooler(MotherBoard motherBoard, CpuCooler cooler);

    bool CompatibilityCoolerAndCorpus(CpuCooler cooler, CasePc casePc);

    bool CompatibilityRamAndMotherBoard(MotherBoard motherBoard, Ram ram);

    bool CompatibilityMotherBoardAndWiFiAdapter(MotherBoard motherBoard, WiFiAdapter wiFiAdapter);

    bool CompatibilityGraphicCardAndCorpus(Gpu gpu, CasePc casePc);

    bool CompatibilityPowerBlock(PowerSupply powerSupply, int summaryPower);

    bool CompatibilityCoolerAndCpu(Cpu cpu, CpuCooler cooler);
}