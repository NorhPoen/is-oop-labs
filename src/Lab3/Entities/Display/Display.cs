using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void Print(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _displayDriver.SetText(text);
    }
}