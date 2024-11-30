using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class TreeListCommandParser : BaseCommandParser
{
    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command[0] == "tree" && command[1] == "list")
        {
            if (command.Length > 3 && command[2] == "-d")
            {
                int depth = int.Parse(command[3], NumberStyles.Integer, new NumberFormatInfo());
                return new TreeListCommand(depth);
            }

            return new TreeListCommand(1);
        }

        return base.ParseCommand(command);
    }
}