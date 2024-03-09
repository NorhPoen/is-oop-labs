using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public abstract class BaseCommandParser : ICommandParser
{
    private ICommandParser? _nextParser;

    public ICommandParser SetNext(ICommandParser parser)
    {
        _nextParser = parser;
        return parser;
    }

    public virtual ICommand ParseCommand(string[] command)
    {
        return _nextParser is not null ? _nextParser.ParseCommand(command) : new InvalidCommand("Unknown request");
    }
}