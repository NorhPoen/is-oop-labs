using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FileCopyCommandParser : BaseCommandParser
{
    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command[0] != "file" || command[1] != "copy") return base.ParseCommand(command);
        if (command.Length <= 3) return new InvalidCommand("Copy");
        string from = command[2];
        string to = command[3];
        return new CopyCommand(from, to);
    }
}