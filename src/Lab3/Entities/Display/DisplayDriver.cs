using System;
using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DisplayDriver : IDisplayDriver
{
    public void ConsoleClean()
    {
        Console.Clear();
    }

    public void ConsoleSetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void ConsoleSetText(string text)
    {
        Console.WriteLine(text);
    }

    public void FileSetText(string pathFile, string text, ConsoleColor textColor)
    {
        Console.ForegroundColor = textColor;
        File.WriteAllText(pathFile, text);

        byte[] data = Encoding.UTF8.GetBytes(text);
        using var stream = new FileStream(pathFile, FileMode.OpenOrCreate);
        stream.Write(data, 0, data.Length);
    }
}