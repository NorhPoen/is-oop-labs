using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public interface IFileSystem
{
    public string Mode { get; }

    IList<string> GetFiles(string path);

    IList<string> GetDirectories(string path);

    string GetParent(string path);

    bool FileExist(string path);

    bool DirectoryExist(string path);

    string GetFileContent(string path);
    IResult FileMove(string sourcePath, string destinationPath);
    IResult FileCopy(string sourcePath, string destinationPath);
    IResult FileDelete(string path);
    IResult FileRename(string path, string newName);
}