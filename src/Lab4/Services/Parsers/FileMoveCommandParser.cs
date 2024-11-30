using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FileMoveCommandParser : BaseCommandParser
{
    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command[0] != "file" || command[1] != "move") return base.ParseCommand(command);
        if (command.Length <= 3) return new InvalidCommand("Move");
        string oldPath = command[2];
        string newPath = command[3];
        return new MoveCommand(oldPath, newPath);
    }
}