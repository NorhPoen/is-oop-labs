using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemObjects;

public class FileObject : FileSystemObject
{
    public FileObject(string path, string symbol = "File: ")
        : base(path, symbol)
    {
    }

    public override IList<FileSystemObject>? ReturnSubObjects()
    {
        return null;
    }
}