using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ShowFile;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Factory;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var handler = new Executor(new FileSystemManager());
        ICommandParser startCommand = new ConnectCommandParser(new FileSystemFactory(new List<IFileSystem> { new LocalFileSystem() }));
        startCommand.SetNext(new DisconnectCommandParser())
            .SetNext(new FileCopyCommandParser())
            .SetNext(new FileDeleteCommandParser())
            .SetNext(new FileMoveCommandParser())
            .SetNext(new FileRenameCommandParser())
            .SetNext(new FileShowCommandParser(new ShowFilesFactory(new List<IShow> { new ConsoleShow() })))
            .SetNext(new TreeGotoCommandParser())
            .SetNext(new TreeListCommandParser())
            .SetNext(new ExitCommandParser());
        var parser = new Parser(startCommand);
        while (handler.Working)
        {
            string? commandString = Console.ReadLine();
            if (commandString is not null)
            {
                ICommand command = parser.Parse(commandString);
                Models.Result.IResult result = handler.DoCommand(command);
                Console.WriteLine(result.Message);
            }
        }
    }
}