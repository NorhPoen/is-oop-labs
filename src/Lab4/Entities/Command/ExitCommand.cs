using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;

public class ExitCommand : ICommand
{
    public IResult Execute(FileSystemManager manager)
    {
        return new SuccessResult("Exit");
    }
}