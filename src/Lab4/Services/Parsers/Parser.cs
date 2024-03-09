using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class Parser : IParser
{
    private ICommandParser _commandParser;

    public Parser(ICommandParser commandParser)
    {
        _commandParser = commandParser;
    }

    public ICommand Parse(string command)
    {
        ArgumentNullException.ThrowIfNull(command);
        string[] splitCommand = command.Split(' ');
        return _commandParser.ParseCommand(splitCommand);
    }
}