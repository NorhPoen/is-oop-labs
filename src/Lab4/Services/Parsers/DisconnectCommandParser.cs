using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class DisconnectCommandParser : BaseCommandParser
{
    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command[0] == "disconnect" ? new DisconnectCommand() : base.ParseCommand(command);
    }
}