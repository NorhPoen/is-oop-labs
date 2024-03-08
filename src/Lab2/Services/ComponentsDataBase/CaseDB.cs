using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class CaseDB : IBuildComponentDb<CasePc>
{
    public IList<CasePc> BuildComponentDb()
    {
        var casePcsList = new List<CasePc>();
        var casePcBuilder = new CasePcBuilder();

        casePcsList.Add(casePcBuilder.SetName("DEXP DC-201M").
            SetGpuMaxWidth(300).SetGpuMaxHeight(153).
            SetHeight(360).SetWidth(175).
            SetLenght(360).SetFormFactors(new List<string> { "Micro-ATX", "Mini-ITX" }).GetResult());

        casePcsList.Add(casePcBuilder.SetName("DEEPCOOL CC560").
            SetGpuMaxWidth(370).SetGpuMaxHeight(163).
            SetHeight(477).SetWidth(210).
            SetLenght(416).SetFormFactors(new List<string>
            { "Micro-ATX", "Mini-ITX", "Standard-ATX" }).GetResult());

        casePcsList.Add(casePcBuilder.SetName("DEXP DC-201M").
            SetGpuMaxWidth(300).SetGpuMaxHeight(165).
            SetHeight(455).SetWidth(210).
            SetLenght(380).SetFormFactors(new List<string>
            { "Micro-ATX", "Mini-ITX", "Standard-ATX" }).GetResult());

        return casePcsList;
    }

    public IList<CasePc> AddNewComponent(IList<CasePc> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<CasePc> updatedDb = BuildComponentDb();
        foreach (CasePc tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}