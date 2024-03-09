using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FileDeleteCommandParser : BaseCommandParser
{
    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command[0] != "file" || command[1] != "delete") return base.ParseCommand(command);
        string path = command[2];
        return new DeleteCommand(path);
    }
}