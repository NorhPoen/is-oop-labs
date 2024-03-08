using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Ssd : IPrototype<Ssd>
{
    public Ssd(
        string name,
        string connectionType,
        int capacity,
        int readSpeed,
        int writeSpeed,
        int wattage)
    {
        Name = name;
        ConnectionType = connectionType ?? throw new ArgumentNullException(nameof(connectionType));
        Capacity = capacity;
        ReadSpeed = readSpeed;
        WriteSpeed = writeSpeed;
        Wattage = wattage;
    }

    public string Name { get; set; }
    public string ConnectionType { get; set; }
    public int Capacity { get; set; }
    public int ReadSpeed { get; set; }
    public int WriteSpeed { get; set; }
    public int Wattage { get; set; }

    public Ssd Clone()
    {
        return new Ssd(Name, ConnectionType, Capacity, ReadSpeed, WriteSpeed, Wattage);
    }
}