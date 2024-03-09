using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class MoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public MoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public IResult Execute(FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        string sourcePath = manager.GetFullFilePath(_sourcePath);
        string destinationPath = manager.GetFullDirectoryPath(_destinationPath);
        return manager.FileSystem is null
            ? new ExecutionErrorResult("Move")
            : manager.FileSystem.FileMove(sourcePath, destinationPath);
    }
}