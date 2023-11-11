using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.LogSystem;

public class Logger : ILogger
{
    public void DisplayLogMessage(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}