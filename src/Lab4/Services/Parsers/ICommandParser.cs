using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public interface ICommandParser
{
    ICommandParser SetNext(ICommandParser parser);
    ICommand ParseCommand(string[] command);
}