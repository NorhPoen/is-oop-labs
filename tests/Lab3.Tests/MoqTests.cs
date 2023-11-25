using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.LogSystem;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.MessageFilter;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MoqTests
{
    private readonly Message _message;
    private readonly Mock<IRecipient> _recipientMock;
    private readonly int _importance = 200;
    private readonly RecipientWithProxy _proxyRecipient;
    public MoqTests()
    {
        _message = new Message("Test Title", "Test Body");
        _recipientMock = new Mock<IRecipient>();
        Mock<ImportanceLevelFilter> filterMock = new(_importance);
        _proxyRecipient = new RecipientWithProxy(_recipientMock.Object, filterMock.Object);
    }

    [Fact]
    public void SendMessageShouldBeReceivedWhenPriorityIsHigh()
    {
        var importantMessage = new Message("Test Title", "Test Body", 250);

        _proxyRecipient.ReceiveMessage(importantMessage);

        _recipientMock.Verify(recipient => recipient.ReceiveMessage(importantMessage), Times.Once);
    }

    [Fact]
    public void SendMessageShouldBeIgnoredWhenPriorityIsLow()
    {
        var notImportantMessage = new Message("Test Title", "Test Body", 150);

        _proxyRecipient.ReceiveMessage(notImportantMessage);

        _recipientMock.Verify(recipient => recipient.ReceiveMessage(notImportantMessage), Times.Never);
    }

    [Fact]
    public void SendingMessageWithLogIsSuccess()
    {
        var loggerMock = new Mock<IConsoleLogger>();

        var loggerRecipient = new ConsoleLoggerServiceDecorator(_recipientMock.Object, loggerMock.Object);

        loggerRecipient.ReceiveMessage(_message);

        _recipientMock.Verify(recipient => recipient.ReceiveMessage(_message), Times.Once);
        loggerMock.Verify(logger => logger.DisplayLogMessage(_message.Title + " is received"), Times.Once);
    }

    [Fact]
    public void SendingMessageToMessengerIsSuccess()
    {
        var messengerMock = new Mock<IMessenger>();

        var messenger = new RecipientMessenger(messengerMock.Object);

        messenger.ReceiveMessage(_message);

        messengerMock.Verify(recipient => recipient.ReceiveMessage(_message), Times.Once);
    }
}