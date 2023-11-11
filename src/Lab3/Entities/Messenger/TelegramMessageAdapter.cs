using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class TelegramMessageAdapter : IMessenger
{
    private TelegramMessenger _telegramMessenger;

    public TelegramMessageAdapter(TelegramMessenger telegramMessenger)
    {
        _telegramMessenger = telegramMessenger;
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentException("Message can't be null");
        }

        _telegramMessenger.Print(message.Title + message.Body);
    }
}