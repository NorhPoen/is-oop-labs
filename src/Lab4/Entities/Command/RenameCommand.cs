using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class RenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public RenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public IResult Execute(FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        string path = manager.GetFullFilePath(_path);
        return manager.FileSystem is null ? new ExecutionErrorResult("Rename") : manager.FileSystem.FileRename(path, _newName);
    }
}