using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.LogSystem;

public class ConsoleLoggerServiceDecorator : IRecipient
{
    private IRecipient _recipient;
    private IConsoleLogger _consoleLogger;

    public ConsoleLoggerServiceDecorator(IRecipient recipient, IConsoleLogger consoleLogger)
    {
        ArgumentNullException.ThrowIfNull(recipient);
        ArgumentNullException.ThrowIfNull(consoleLogger);
        _recipient = recipient;
        _consoleLogger = consoleLogger;
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _consoleLogger.DisplayLogMessage(message.Title + " is received");
        _recipient.ReceiveMessage(message);
    }
}