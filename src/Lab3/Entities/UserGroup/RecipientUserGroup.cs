using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.UserGroup;

public class RecipientUserGroup : IRecipient
{
    private readonly IList<IRecipient> _adresats;

    public RecipientUserGroup(IList<IRecipient> adresats)
    {
        ArgumentNullException.ThrowIfNull(adresats);
        _adresats = adresats;
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        foreach (IRecipient adresat in _adresats)
        {
            adresat.ReceiveMessage(message);
        }
    }
}