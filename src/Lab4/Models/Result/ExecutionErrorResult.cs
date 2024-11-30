namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Result;

public class ExecutionErrorResult : IResult
{
    public ExecutionErrorResult(string message)
    {
        Message = "Execution error to command: " + message;
    }

    public string Message { get; init; }
}