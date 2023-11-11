using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplay
{
    void Print(string text, ConsoleColor color);
    void PrintFile(string filePath, string text, ConsoleColor color);
}