using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class RecipientMessenger : IRecipient
{
    private IMessenger _messenger;

    public RecipientMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentException("message can't be null");
        }

        _messenger.ReceiveMessage(message);
    }
}