using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class ExitCommandParser : BaseCommandParser
{
    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command[0] == "exit" ? new ExitCommand() : base.ParseCommand(command);
    }
}