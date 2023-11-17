using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class TelegramMessageAdapter : IMessenger
{
    private TelegramMessenger _telegramMessenger;

    public TelegramMessageAdapter(TelegramMessenger telegramMessenger)
    {
        ArgumentNullException.ThrowIfNull(telegramMessenger);
        _telegramMessenger = telegramMessenger;
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _telegramMessenger.Print(message.Title + message.Body);
    }
}