namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string title, string body)
    {
        Title = title;
        Body = body;
    }

    public Message(string title, string body, int importanceLvl)
    {
        Title = title;
        Body = body;
        ImportanceLvl = importanceLvl;
    }

    public string Title { get; }
    public string Body { get; }
    public int ImportanceLvl { get; }
}