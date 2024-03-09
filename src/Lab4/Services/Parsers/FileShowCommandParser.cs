using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ShowFile;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Factory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FileShowCommandParser : BaseCommandParser
{
    private ShowFilesFactory _showFilesFactory;

    public FileShowCommandParser(ShowFilesFactory showFilesFactory)
    {
        _showFilesFactory = showFilesFactory;
    }

    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command[0] != "file" || command[1] != "show") return base.ParseCommand(command);
        if (command.Length <= 4 || command[3] != "-m") return new InvalidCommand("Show");
        string path = command[2];
        string mode = command[4];
        IShow? show = _showFilesFactory.GetShowFilesByMode(mode);
        if (show is null)
        {
            return new InvalidCommand("Show");
        }

        return new ShowCommand(show, path);
    }
}