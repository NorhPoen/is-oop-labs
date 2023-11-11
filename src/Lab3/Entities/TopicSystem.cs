using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class TopicSystem
{
    private readonly List<Topic> _topics = new List<Topic>();

    public void AddTopic(Topic topic)
    {
        _topics.Add(topic);
    }

    public void RemoveTopic(string topicName)
    {
        Topic topic = _topics.FirstOrDefault(x => string.Equals(x.Name, topicName, StringComparison.Ordinal)) ?? throw new ArgumentException("topic can't be found");
        _topics.Remove(topic);
    }

    public void SendTopic(Message message, string topicName)
    {
        Topic topic = _topics.FirstOrDefault(x => string.Equals(x.Name, topicName, StringComparison.Ordinal)) ?? throw new ArgumentException("topic can't be found");
        topic.SendMessage(message);
    }
}