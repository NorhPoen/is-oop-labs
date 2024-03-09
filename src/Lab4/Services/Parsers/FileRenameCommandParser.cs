using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FileRenameCommandParser : BaseCommandParser
{
    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command[0] != "file" || command[1] != "rename") return base.ParseCommand(command);
        if (command.Length <= 3) return new InvalidCommand("Rename");
        string path = command[2];
        string name = command[3];
        return new RenameCommand(path, name);
    }
}