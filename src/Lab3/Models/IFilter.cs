using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IFilter
{
    public bool FilterMessage(Message message);
}