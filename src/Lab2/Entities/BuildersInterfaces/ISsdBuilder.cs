using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface ISsdBuilder
{
    ISsdBuilder SetName(string name);
    ISsdBuilder SetConnectionType(string connectionType);
    ISsdBuilder SetCapacity(int capacity);
    ISsdBuilder SetReadSpeed(int readSpeed);
    ISsdBuilder SetWriteSpeed(int writeSpeed);
    ISsdBuilder SetWattage(int wattage);
    Ssd GetResult();
}