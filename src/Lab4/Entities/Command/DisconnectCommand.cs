using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class DisconnectCommand : ICommand
{
    public IResult Execute(FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        manager.FileSystem = null;
        manager.RootPath = null;
        manager.Context = null;
        return new SuccessResult("Disconnect");
    }
}