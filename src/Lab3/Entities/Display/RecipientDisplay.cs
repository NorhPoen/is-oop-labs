using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class RecipientDisplay : IRecipient
{
    private readonly IDisplay _display;

    public RecipientDisplay(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        string text = message.Title + message.Body;
        _display.Print(text);
    }
}