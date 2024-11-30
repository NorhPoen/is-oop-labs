using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class CasePcFactory : IComponentFactory<CasePc>
{
    private readonly IList<CasePc> _casePcList;

    public CasePcFactory(IList<CasePc> casePcList)
    {
        _casePcList = new CaseDB().AddNewComponent(casePcList);
    }

    public CasePcFactory()
    {
        _casePcList = new CaseDB().BuildComponentDb();
    }

    public CasePc? CreateComponentByName(string componentName)
    {
        return _casePcList
            .FirstOrDefault(pcCase => pcCase.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}