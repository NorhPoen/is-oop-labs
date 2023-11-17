using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class RecipientMessenger : IRecipient
{
    private IMessenger _messenger;

    public RecipientMessenger(IMessenger messenger)
    {
        ArgumentNullException.ThrowIfNull(messenger);
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messenger.ReceiveMessage(message);
    }
}