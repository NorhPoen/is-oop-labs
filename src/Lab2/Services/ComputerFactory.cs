using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerFactory
{
    private readonly IComponentFactory<Cpu> _cpuFactory;
    private readonly IComponentFactory<MotherBoard> _motherBoardFactory;
    private readonly IComponentFactory<Ram> _ramFactory;
    private readonly IComponentFactory<CpuCooler> _coolerFactory;
    private readonly IComponentFactory<CasePc> _corpusFactory;
    private readonly IComponentFactory<Gpu> _graphicCardFactory;
    private readonly IComponentFactory<Hdd> _hddFactory;
    private readonly IComponentFactory<Ssd> _ssdFactory;
    private readonly IComponentFactory<PowerSupply> _powerBlockFactory;
    private readonly IComponentFactory<WiFiAdapter> _wiFiAdapterFactory;

    public ComputerFactory(IComponentFactory<Cpu> cpuFactory, IComponentFactory<MotherBoard> motherBoardFactory, IComponentFactory<Ram> ramFactory, IComponentFactory<CpuCooler> coolerFactory, IComponentFactory<CasePc> corpusFactory, IComponentFactory<Gpu> graphicCardFactory, IComponentFactory<Hdd> hddFactory, IComponentFactory<Ssd> ssdFactory, IComponentFactory<PowerSupply> powerBlockFactory, IComponentFactory<WiFiAdapter> wiFiAdapterFactory)
    {
        _cpuFactory = cpuFactory;
        _motherBoardFactory = motherBoardFactory;
        _ramFactory = ramFactory;
        _coolerFactory = coolerFactory;
        _corpusFactory = corpusFactory;
        _graphicCardFactory = graphicCardFactory;
        _hddFactory = hddFactory;
        _ssdFactory = ssdFactory;
        _powerBlockFactory = powerBlockFactory;
        _wiFiAdapterFactory = wiFiAdapterFactory;
    }

    public Cpu? CreateCpuByName(string name)
    {
        return _cpuFactory.CreateComponentByName(name);
    }

    public MotherBoard? CreateMotherBoardByName(string name)
    {
        return _motherBoardFactory.CreateComponentByName(name);
    }

    public Ram? CreateRamStickByName(string name)
    {
        return _ramFactory.CreateComponentByName(name);
    }

    public CpuCooler? CreateCoolerByName(string name)
    {
        return _coolerFactory.CreateComponentByName(name);
    }

    public CasePc? CreateCorpusByName(string name)
    {
        return _corpusFactory.CreateComponentByName(name);
    }

    public Gpu? CreateGraphicCardByName(string name)
    {
        return _graphicCardFactory.CreateComponentByName(name);
    }

    public Hdd? CreateHddByName(string name)
    {
        return _hddFactory.CreateComponentByName(name);
    }

    public Ssd? CreateSsdByName(string name)
    {
        return _ssdFactory.CreateComponentByName(name);
    }

    public PowerSupply? CreatePowerBlockByName(string name)
    {
        return _powerBlockFactory.CreateComponentByName(name);
    }

    public WiFiAdapter? CreateWiFiAdapterByName(string name)
    {
        return _wiFiAdapterFactory.CreateComponentByName(name);
    }
}