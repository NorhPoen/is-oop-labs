using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Factory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class ConnectCommandParser : BaseCommandParser
{
    private FileSystemFactory _fileSystemFactory;

    public ConnectCommandParser(FileSystemFactory fileSystemFactory)
    {
        _fileSystemFactory = fileSystemFactory;
    }

    public override ICommand ParseCommand(string[] command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command[0] != "connect") return base.ParseCommand(command);
        if (command.Length <= 3 || command[2] != "-m") return new InvalidCommand("Connect");
        string address = command[1];
        string mode = command[3];
        IFileSystem? fileSystem = _fileSystemFactory.GetFileSystemByMode(mode);
        if (fileSystem is null)
        {
            return new InvalidCommand("Connect");
        }

        return new ConnectCommand(address, fileSystem);
    }
}