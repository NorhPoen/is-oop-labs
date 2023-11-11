using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class TelegramMessenger : ITelegramMessenger
{
    private string _message;

    public TelegramMessenger(string message)
    {
        _message = message;
    }

    public void Print(string message)
    {
        Console.WriteLine("Telegram message: " + message);
    }
}