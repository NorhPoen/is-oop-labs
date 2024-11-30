using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Iterator;

public class Iterator : IEnumerable<FileSystemObject>
{
    private string _rootPath;
    private IFileSystem _fileSystem;
    private string? _fileSymbol;
    private string? _folderSymbol;

    public Iterator(string rootPath, IFileSystem fileSystem, string? fileSymbol, string? folderSymbol)
    {
        _rootPath = rootPath;
        _fileSystem = fileSystem;
        _fileSymbol = fileSymbol;
        _folderSymbol = folderSymbol;
    }

    public IEnumerator<FileSystemObject> GetEnumerator()
    {
        return new DeepIterator(_rootPath, _fileSystem, _fileSymbol, _folderSymbol);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new DeepIterator(_rootPath, _fileSystem, _fileSymbol, _folderSymbol);
    }
}