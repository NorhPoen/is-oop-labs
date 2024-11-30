using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class MotherBoardFactory : IComponentFactory<MotherBoard>
{
    private readonly IList<MotherBoard> _motherBoardList;

    public MotherBoardFactory(IList<MotherBoard> motherBoardList)
    {
        _motherBoardList = new MotherBoardDB().AddNewComponent(motherBoardList);
    }

    public MotherBoardFactory()
    {
        _motherBoardList = new MotherBoardDB().BuildComponentDb();
    }

    public MotherBoard? CreateComponentByName(string componentName)
    {
        return _motherBoardList
            .FirstOrDefault(motherBoard => motherBoard.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase))?.Clone();
    }
}