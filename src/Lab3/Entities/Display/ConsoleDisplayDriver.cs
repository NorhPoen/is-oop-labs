using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private ConsoleColor _color;

    public ConsoleDisplayDriver(ConsoleColor color)
    {
        ArgumentNullException.ThrowIfNull(color);
        _color = color;
    }

    public void SetText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        Console.Clear();
        Console.ForegroundColor = _color;
        Console.WriteLine(text);
    }
}