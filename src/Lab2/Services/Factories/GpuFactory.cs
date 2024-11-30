using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class GpuFactory : IComponentFactory<Gpu>
{
    private readonly IList<Gpu> _gpuList;

    public GpuFactory(IList<Gpu> gpuList)
    {
        _gpuList = new GpuDB().AddNewComponent(gpuList);
    }

    public GpuFactory()
    {
        _gpuList = new GpuDB().BuildComponentDb();
    }

    public Gpu? CreateComponentByName(string componentName)
    {
        return _gpuList
            .FirstOrDefault(gpu => gpu.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}