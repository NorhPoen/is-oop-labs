using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.UserAdresat;

public class User
{
    public User(IList<UserMessage> messages)
    {
        Messages = messages;
    }

    public IList<UserMessage> Messages { get; }

    public void ReceiveMessage(UserMessage message)
    {
        Messages.Add(message);
    }

    public void MarkAsRead(UserMessage message)
    {
        int ind = Messages.IndexOf(message);
        if (Messages[ind].IsRead)
        {
            throw new ArgumentException("You can't read same message twice");
        }

        Messages[ind].IsRead = true;
    }
}