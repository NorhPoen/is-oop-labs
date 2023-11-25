using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string title, string body)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(body);
        Title = title;
        Body = body;
    }

    public Message(string title, string body, int importanceLvl)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(body);
        Title = title;
        Body = body;
        ImportanceLvl = importanceLvl;
    }

    public string Title { get; }
    public string Body { get; }
    public int ImportanceLvl { get; }
}