using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void Print(string text, ConsoleColor color)
    {
        _displayDriver.ConsoleClean();
        _displayDriver.ConsoleSetColor(color);
        _displayDriver.ConsoleSetText(text);
    }

    public void PrintFile(string filePath, string text, ConsoleColor color)
    {
       _displayDriver.FileSetText(filePath, text, color);
    }
}