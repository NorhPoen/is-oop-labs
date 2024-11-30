using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public string Mode { get; init; } = "local";
    public IList<string> GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public IList<string> GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public string GetParent(string path)
    {
        DirectoryInfo? parent = Directory.GetParent(path);
        return parent is null ? Directory.GetCurrentDirectory() : parent.ToString();
    }

    public bool FileExist(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExist(string path)
    {
        return Directory.Exists(path);
    }

    public string GetFileContent(string path)
    {
        return File.ReadAllText(path);
    }

    public IResult FileMove(string sourcePath, string destinationPath)
    {
        string goodName = GetNameWithoutCollision(Path.GetFileName(sourcePath), destinationPath);
        string fullPath = Path.Combine(destinationPath, goodName);
        File.Move(sourcePath, fullPath);

        if (!File.Exists(fullPath))
        {
            return new ExecutionErrorResult("Move");
        }

        return new SuccessResult("Success");
    }

    public IResult FileCopy(string sourcePath, string destinationPath)
    {
        string goodName = GetNameWithoutCollision(Path.GetFileName(sourcePath), destinationPath);
        string fullPath = Path.Combine(destinationPath, goodName);

        File.Copy(sourcePath, fullPath);

        if (!File.Exists(fullPath))
        {
            return new ExecutionErrorResult("Copy");
        }

        return new SuccessResult("Copy");
    }

    public IResult FileDelete(string path)
    {
        if (!File.Exists(path))
        {
            return new ExecutionErrorResult("Delete");
        }

        File.Delete(path);
        return new SuccessResult("Delete");
    }

    public IResult FileRename(string path, string newName)
    {
        if (!File.Exists(path))
        {
            return new ExecutionErrorResult("Rename");
        }

        string? directory = Path.GetDirectoryName(path);
        string goodName;
        if (directory is not null)
        {
            goodName = GetNameWithoutCollision(newName, directory);
        }
        else
        {
            goodName = GetNameWithoutCollision(newName, Directory.GetCurrentDirectory());
        }

        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(path, goodName);
        return new SuccessResult("Rename");
    }

    public string GetNameWithoutCollision(string name, string directory)
    {
        int tmp = 1;
        if (!File.Exists(Path.Combine(directory, name))) return name;
        string pathWithoutExtension = Path.GetFileNameWithoutExtension(name);
        while (File.Exists(Path.Combine(directory, name)))
        {
            name = $"{pathWithoutExtension}-{tmp}{Path.GetExtension(name)}";
            tmp++;
        }

        return name;
    }
}