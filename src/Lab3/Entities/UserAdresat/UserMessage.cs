using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.UserAdresat;

public class UserMessage
{
    public UserMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        MessageUser = message;
        IsRead = false;
    }

    public Message MessageUser { get; set; }
    public bool IsRead { get; set; }
}