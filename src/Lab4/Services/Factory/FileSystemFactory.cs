using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Factory;

public class FileSystemFactory
{
    private IList<IFileSystem> _fileSystems;

    public FileSystemFactory(IList<IFileSystem> fileSystems)
    {
        _fileSystems = fileSystems;
    }

    public IFileSystem? GetFileSystemByMode(string mode)
    {
        IFileSystem? result = _fileSystems.FirstOrDefault(system => system.Mode == mode);
        return result;
    }
}