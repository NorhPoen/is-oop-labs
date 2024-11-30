using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ShowFile;

public class ConsoleShow : IShow
{
    public string Mode { get; init; } = "console";
    public void Show(string text)
    {
        Console.WriteLine(text);
    }
}