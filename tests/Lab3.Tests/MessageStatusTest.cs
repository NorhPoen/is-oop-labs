using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.UserAdresat;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageStatusTest
{
    private readonly Message _message1;
    private readonly Message _message2;
    private readonly Message _message3;
    private readonly UserMessage _userMessage1;
    private readonly UserMessage _userMessage2;
    private readonly UserMessage _userMessage3;

    public MessageStatusTest()
    {
        _message1 = new Message("Test Title1", "Test Body1", 238);
        _message2 = new Message("Test Title2", "Test Body2", 239);
        _message3 = new Message("Test Title3", "Test Body3", 240);

        _userMessage1 = new UserMessage(_message1);
        _userMessage2 = new UserMessage(_message2);
        _userMessage3 = new UserMessage(_message3);
    }

    [Fact]
    public void NewMessageIsUnread()
    {
        var user = new RecipientUser(new User(new List<UserMessage>()));

        user.ReceiveMessage(_message1);
        user.ReceiveMessage(_message2);
        user.ReceiveMessage(_message3);

        Func<UserMessage, bool> predicate = msgUser => msgUser.IsRead;

        bool allMsgsUnread = user.User.Messages.All(predicate);

        Assert.False(allMsgsUnread);
    }

    [Fact]
    public void UserChangingMessageStatus()
    {
        var user = new RecipientUser(new User(new List<UserMessage>()));

        user.User.ReceiveMessage(_userMessage1);
        user.User.ReceiveMessage(_userMessage2);
        user.User.ReceiveMessage(_userMessage3);

        Func<UserMessage, bool> predicate = msgUser => msgUser.IsRead;

        bool allMsgsUnread = user.User.Messages.All(predicate);

        Assert.False(allMsgsUnread);

        user.User.MarkAsRead(_userMessage1);
        user.User.MarkAsRead(_userMessage2);
        user.User.MarkAsRead(_userMessage3);

        bool allMsgsRead = user.User.Messages.All(predicate);

        Assert.True(allMsgsRead);
    }

    [Fact]
    public void ReadingMessageTwiceError()
    {
        var user = new RecipientUser(new User(new List<UserMessage>()));

        user.User.ReceiveMessage(_userMessage1);
        user.User.ReceiveMessage(_userMessage2);

        user.User.MarkAsRead(_userMessage2);

        bool testFailed = false;

        try
        {
            user.User.MarkAsRead(_userMessage2);
        }
        catch (ArgumentException)
        {
            testFailed = true;
        }

        Assert.True(testFailed);
    }
}