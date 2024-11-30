using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Microsoft.VisualBasic.CompilerServices;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TreeListWalker;

public class TreeListWalker : ITreeListWalker
{
    public void ShowTreeList(int depth, FileSystemManager manager)
    {
        ArgumentNullException.ThrowIfNull(manager);
        if (manager.Context is null || manager.FileSystem is null)
        {
            throw new IncompleteInitialization();
        }

        var fileSystemIterator = new Iterator.Iterator(manager.Context, manager.FileSystem, manager.FileSymbol, manager.FolderSymbol);

        foreach (FileSystemObject obj in fileSystemIterator)
        {
            int fileDepth = obj.Path.Split(Path.DirectorySeparatorChar).Length - manager.Context.Split(Path.DirectorySeparatorChar).Length;
            if (fileDepth <= depth)
            {
                Console.WriteLine($"{new string('-', fileDepth * 2)} " + $"{obj.Symbol} " + $"{Path.GetFileName(obj.Path)}");
            }
        }
    }
}