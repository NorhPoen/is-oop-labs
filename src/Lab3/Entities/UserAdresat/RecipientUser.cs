using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.UserAdresat;

public class RecipientUser : IRecipient
{
    public RecipientUser(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        User = user;
    }

    public User User { get; set; }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        User.ReceiveMessage(new UserMessage(message));
    }
}