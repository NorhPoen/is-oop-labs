using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessageFilter;

public class RecipientWithProxy : IRecipient
{
    private IRecipient _recipient;
    private int _minImportanceLvl;

    public RecipientWithProxy(IRecipient recipient, int minImportanceLvl)
    {
        _recipient = recipient;
        _minImportanceLvl = minImportanceLvl;
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentException("Message can't be null");
        }

        if (message.ImportanceLvl >= _minImportanceLvl)
        {
            _recipient.ReceiveMessage(message);
        }
    }
}