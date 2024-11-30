using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ShowFile;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Factory;

public class ShowFilesFactory
{
    private IList<IShow> _showFiles;

    public ShowFilesFactory(IList<IShow> showFiles)
    {
        _showFiles = showFiles;
    }

    public IShow? GetShowFilesByMode(string mode)
    {
        IShow? result = _showFiles.FirstOrDefault(show => show.Mode == mode);
        return result;
    }
}