using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.LogSystem;

public class LoggerServiceDecorator : IRecipient
{
    private IRecipient _recipient;
    private ILogger _logger;

    public LoggerServiceDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentException("Message can't be empty");
        }

        _logger.DisplayLogMessage(message.Title + " is received");
        _recipient.ReceiveMessage(message);
    }
}