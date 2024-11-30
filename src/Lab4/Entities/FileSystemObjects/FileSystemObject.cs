using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemObjects;

public abstract class FileSystemObject
{
    protected FileSystemObject(string path, string symbol = " ")
    {
        Path = path;
        Symbol = symbol;
    }

    public string Path { get; }

    public string Symbol { get; }

    public abstract IList<FileSystemObject>? ReturnSubObjects();
}