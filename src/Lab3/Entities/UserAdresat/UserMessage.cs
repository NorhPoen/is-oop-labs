namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.UserAdresat;

public class UserMessage
{
    public UserMessage(Message message)
    {
        MessageUser = message;
        IsRead = false;
    }

    public Message MessageUser { get; set; }
    public bool IsRead { get; set; }
}