using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ConfigSpecification;

public interface IBuilderSpecification
{
    IBuilderSpecification WithMotherBoard(string motherBoard);

    IBuilderSpecification WithCpu(string cpu);

    IBuilderSpecification WithSsd(string ssd);

    IBuilderSpecification WithSsd(IList<string> ssds);

    IBuilderSpecification WithHdd(string hdd);

    IBuilderSpecification WithHdd(IList<string> hdds);

    IBuilderSpecification WithCorpus(string casePc);

    IBuilderSpecification WithCooler(string cpuCooler);

    IBuilderSpecification WithPowerBlock(string powerSupply);

    IBuilderSpecification WithGraphicCard(string gpu);

    IBuilderSpecification WithWiFiAdapter(string wiFiAdapter);

    IBuilderSpecification WithRamStick(string ram);

    IBuilderSpecification WithRamStick(IList<string> rams);
}