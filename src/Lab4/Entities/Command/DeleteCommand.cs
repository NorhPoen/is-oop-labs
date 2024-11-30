using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class DeleteCommand : ICommand
{
    private readonly string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public IResult Execute(FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        ArgumentNullException.ThrowIfNull(manager.FileSystem);
        string path = manager.GetFullFilePath(_path);
        return manager.FileSystem is null ? new ExecutionErrorResult("Delete") : manager.FileSystem.FileDelete(path);
    }
}