using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessageFilter;

public class RecipientWithProxy : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly IFilter _filter;

    public RecipientWithProxy(IRecipient recipient, IFilter filter)
    {
        ArgumentNullException.ThrowIfNull(recipient);
        ArgumentNullException.ThrowIfNull(filter);
        _recipient = recipient;
        _filter = filter;
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (_filter.FilterMessage(message))
        {
            _recipient.ReceiveMessage(message);
        }
    }
}