using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.LogSystem;

public class ConsoleLogger : IConsoleLogger
{
    public void DisplayLogMessage(string logMessage)
    {
        ArgumentNullException.ThrowIfNull(logMessage);
        Console.WriteLine(logMessage);
    }
}