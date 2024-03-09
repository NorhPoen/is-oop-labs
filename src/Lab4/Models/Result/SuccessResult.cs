namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Result;

public class SuccessResult : IResult
{
    public SuccessResult(string message)
    {
        Message = "Success result command: " + message;
    }

    public string Message { get; init; }
}