using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class CopyCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public IResult Execute(FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        ArgumentNullException.ThrowIfNull(manager.FileSystem);
        string sourcePath = manager.GetFullFilePath(_sourcePath);
        string destinationPath = manager.GetFullDirectoryPath(_destinationPath);
        return manager.FileSystem.FileCopy(sourcePath, destinationPath);
    }
}