using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemObjects;

public class Folder : FileSystemObject
{
    public Folder(string path, string symbol = "Folder: ")
        : base(path, symbol)
    {
    }

    public IList<FileSystemObject> FolderObjects { get; } = new List<FileSystemObject>();

    public override IList<FileSystemObject>? ReturnSubObjects()
    {
        return FolderObjects;
    }
}