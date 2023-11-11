namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    public Topic(string name, IRecipient recipient)
    {
        Name = name;
        Recipient = recipient;
    }

    public string Name { get; }
    private IRecipient Recipient { get; }

    public void SendMessage(Message message)
    {
        Recipient.ReceiveMessage(message);
    }
}