using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ShowFile;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class ShowCommand : ICommand
{
    private readonly IShow _show;
    private readonly string _path;

    public ShowCommand(IShow show, string path)
    {
        _show = show;
        _path = path;
    }

    public IResult Execute(FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        if (manager.FileSystem is null)
        {
            return new ExecutionErrorResult("Show");
        }

        string path = manager.GetFullFilePath(_path);

        if (!manager.FileSystem.FileExist(path)) return new ExecutionErrorResult("Show");
        _show.Show(manager.FileSystem.GetFileContent(path));
        return new SuccessResult("Show");
    }
}