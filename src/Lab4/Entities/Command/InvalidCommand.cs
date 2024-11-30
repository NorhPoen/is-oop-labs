using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class InvalidCommand : ICommand
{
    private readonly string _message;

    public InvalidCommand(string message)
    {
        _message = message;
    }

    public IResult Execute(FileSystemManager manager)
    {
        return new InvalidRequestResult(_message);
    }
}