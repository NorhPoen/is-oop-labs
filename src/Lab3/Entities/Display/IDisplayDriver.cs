using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplayDriver
{
    void ConsoleClean();
    void ConsoleSetColor(ConsoleColor color);
    void ConsoleSetText(string text);
    void FileSetText(string pathFile, string text, ConsoleColor textColor);
}