using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class FileDisplayDriver : IDisplayDriver, IDisposable
{
    private readonly StreamWriter _stream;

    public FileDisplayDriver(string pathFile)
    {
        if (IsFilePath(pathFile))
        {
            if (!File.Exists(pathFile))
            {
                throw new FileNotFoundException("The file does not exist");
            }

            _stream = new StreamWriter(pathFile, true);
        }
        else
        {
            throw new ArgumentException("The path is not valid");
        }
    }

    public void SetText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _stream.WriteLine(text);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        _stream.Close();
    }

    private bool IsFilePath(string path)
    {
        return Path.IsPathRooted(path) && !string.IsNullOrEmpty(Path.GetFileName(path));
    }
}