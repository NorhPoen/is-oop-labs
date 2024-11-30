using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public IResult Execute(FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        manager.TreeListWalker.ShowTreeList(_depth, manager);
        return new SuccessResult("TreeList");
    }
}