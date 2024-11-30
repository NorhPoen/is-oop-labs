using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Iterator;

public sealed class DeepIterator : IEnumerator<FileSystemObject>
{
    private IFileSystem _fileSystem;
    private string? _fileSymbol;
    private string? _folderSymbol;
    public DeepIterator(string rootPath, IFileSystem fileSystem, string? fileSymbol, string? folderSymbol)
    {
        _fileSystem = fileSystem;
        _fileSymbol = fileSymbol;
        _folderSymbol = folderSymbol;
        Current = MakeSystemObject(rootPath);
        Stack.Push(Current);
    }

    public FileSystemObject Current { get; private set; }

    object IEnumerator.Current => Current;

    private Stack<FileSystemObject> Stack { get; } = new();

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (Equals(Stack.Count, 0))
        {
            return false;
        }

        Current = Stack.Pop();
        IList<FileSystemObject>? objects = Current.ReturnSubObjects();
        if (objects is null) return true;
        foreach (FileSystemObject obj in objects)
        {
            Stack.Push(obj);
        }

        return true;
    }

    public void Reset()
    {
    }

    private FileSystemObject MakeSystemObject(string path)
    {
        if (_fileSystem.FileExist(path))
        {
            return _fileSymbol is not null ? new FileObject(path, _fileSymbol) : new FileObject(path);
        }

        Folder folder = _folderSymbol is not null ? new Folder(path, _folderSymbol) : new Folder(path);

        foreach (string objects in _fileSystem.GetFiles(path))
        {
            FileSystemObject obj = MakeSystemObject(objects);
            folder.FolderObjects.Add(obj);
        }

        foreach (string objects in _fileSystem.GetDirectories(path))
        {
            FileSystemObject obj = MakeSystemObject(objects);
            folder.FolderObjects.Add(obj);
        }

        return folder;
    }
}