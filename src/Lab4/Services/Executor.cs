using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class Executor
{
    private FileSystemManager _manager;

    public Executor(FileSystemManager manager)
    {
        _manager = manager;
    }

    public bool Working { get; private set; } = true;

    public IResult DoCommand(ICommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        if (_manager.FileSystem is null && command is not ConnectCommand)
        {
            Console.WriteLine("You can`t do command before connect command");
        }

        if (command is ExitCommand)
        {
            Working = false;
        }

        return command.Execute(_manager);
    }
}