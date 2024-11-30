using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TreeListWalker;
using Microsoft.VisualBasic.CompilerServices;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FileSystemManager
{
    public IFileSystem? FileSystem { get; set; }
    public string? RootPath { get; set; }
    public string? Context { get; set; }
    public string? FileSymbol { get; set; }
    public string? FolderSymbol { get; set; }

    public ITreeListWalker TreeListWalker { get; set; } = new TreeListWalker();

    public string GetFullFilePath(string path)
    {
        if (Context is null || FileSystem is null)
        {
            throw new IncompleteInitialization();
        }

        ArgumentNullException.ThrowIfNull(path);

        string fullPath = Path.GetFullPath(Path.Combine(Context, path));

        if (!FileSystem.FileExist(fullPath))
        {
            throw new FileNotFoundException(fullPath);
        }

        return fullPath;
    }

    public string GetFullDirectoryPath(string path)
    {
        if (Context is null || FileSystem is null)
        {
            throw new IncompleteInitialization();
        }

        ArgumentNullException.ThrowIfNull(path);

        string fullPath = Path.GetFullPath(Path.Combine(Context, path));

        if (!FileSystem.DirectoryExist(fullPath))
        {
            throw new DirectoryNotFoundException(fullPath);
        }

        return fullPath;
    }
}