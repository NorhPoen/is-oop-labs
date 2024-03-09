namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Result;

public class InvalidRequestResult : IResult
{
    public InvalidRequestResult(string message)
    {
        Message = "Invalid request to command: " + message;
    }

    public string Message { get; init; }
}