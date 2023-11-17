using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class ImportanceLevelFilter : IFilter
{
    private int _minimumImportanceLevel;

    public ImportanceLevelFilter(int minimumImportanceLevel)
    {
        _minimumImportanceLevel = minimumImportanceLevel;
    }

    public bool FilterMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        return message.ImportanceLvl >= _minimumImportanceLevel;
    }
}