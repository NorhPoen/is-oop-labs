using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.LogSystem;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.MessageFilter;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MoqTests
{
    [Fact]
    public void SendMessageShouldBeReceivedWhenPriorityIsHigh()
    {
        var importantMessage = new Message("Test Title", "Test Body", 250);

        const int importance = 200;
        var recipientMock = new Mock<IRecipient>();

        var proxyRecipientMock = new RecipientWithProxy(recipientMock.Object, importance);

        proxyRecipientMock.ReceiveMessage(importantMessage);

        recipientMock.Verify(recipient => recipient.ReceiveMessage(importantMessage), Times.Once);
    }

    [Fact]
    public void SendMessageShouldBeIgnoredWhenPriorityIsLow()
    {
        var notImportantMessage = new Message("Test Title", "Test Body", 150);

        const int importance = 200;
        var recipientMock = new Mock<IRecipient>();

        var proxyRecipientMock = new RecipientWithProxy(recipientMock.Object, importance);

        proxyRecipientMock.ReceiveMessage(notImportantMessage);

        recipientMock.Verify(recipient => recipient.ReceiveMessage(notImportantMessage), Times.Never);
    }

    [Fact]
    public void SendingMessageWithLogIsSuccess()
    {
        var message = new Message("Test Title", "Test Body");

        var loggerMock = new Mock<ILogger>();
        var recipientMock = new Mock<IRecipient>();

        var loggerRecipient = new LoggerServiceDecorator(recipientMock.Object, loggerMock.Object);

        loggerRecipient.ReceiveMessage(message);

        recipientMock.Verify(recipient => recipient.ReceiveMessage(message), Times.Once);

        loggerMock.Verify(logger => logger.DisplayLogMessage(message.Title + " is received"), Times.Once);
    }

    [Fact]
    public void SendingMessageToMessengerIsSuccess()
    {
        var message = new Message("Test Title", "Test Body");

        var messengerMock = new Mock<IMessenger>();

        var messenger = new RecipientMessenger(messengerMock.Object);

        messenger.ReceiveMessage(message);

        messengerMock.Verify(recipient => recipient.ReceiveMessage(message), Times.Once);
    }
}