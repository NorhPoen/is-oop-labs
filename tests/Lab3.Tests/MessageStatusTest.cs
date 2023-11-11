using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.UserAdresat;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageStatusTest
{
    [Fact]
    public void NewMessageIsUnread()
    {
        var user = new RecipientUser(new User(new List<UserMessage>()));

        var message1 = new Message("Test Title1", "Test Body1", 238);
        var message2 = new Message("Test Title2", "Test Body2", 239);
        var message3 = new Message("Test Title3", "Test Body3", 240);

        user.ReceiveMessage(message1);
        user.ReceiveMessage(message2);
        user.ReceiveMessage(message3);

        Func<UserMessage, bool> predicate = msgUser => msgUser.IsRead;

        bool allMsgsUnread = user.User.Messages.All(predicate);

        Assert.False(allMsgsUnread);
    }

    [Fact]
    public void UserChangingMessageStatus()
    {
        var user = new RecipientUser(new User(new List<UserMessage>()));

        var message1 = new Message("Test Title1", "Test Body1", 238);
        var message2 = new Message("Test Title2", "Test Body2", 239);
        var message3 = new Message("Test Title3", "Test Body3", 240);

        var userMessage1 = new UserMessage(message1);
        var userMessage2 = new UserMessage(message2);
        var userMessage3 = new UserMessage(message3);

        user.User.ReceiveMessage(userMessage1);
        user.User.ReceiveMessage(userMessage2);
        user.User.ReceiveMessage(userMessage3);

        Func<UserMessage, bool> predicate = msgUser => msgUser.IsRead;

        bool allMsgsUnread = user.User.Messages.All(predicate);

        Assert.False(allMsgsUnread);

        user.User.MarkAsRead(userMessage1);
        user.User.MarkAsRead(userMessage2);
        user.User.MarkAsRead(userMessage3);

        bool allMsgsRead = user.User.Messages.All(predicate);

        Assert.True(allMsgsRead);
    }

    [Fact]
    public void ReadingMessageTwiceError()
    {
        var user = new RecipientUser(new User(new List<UserMessage>()));

        var message1 = new Message("Test Title1", "Test Body1", 238);
        var message2 = new Message("Test Title2", "Test Body2", 239);

        var userMessage1 = new UserMessage(message1);
        var userMessage2 = new UserMessage(message2);

        user.User.ReceiveMessage(userMessage1);
        user.User.ReceiveMessage(userMessage2);

        user.User.MarkAsRead(userMessage2);

        bool testFailed = false;

        try
        {
            user.User.MarkAsRead(userMessage2);
        }
        catch (ArgumentException)
        {
            testFailed = true;
        }

        Assert.True(testFailed);
    }
}