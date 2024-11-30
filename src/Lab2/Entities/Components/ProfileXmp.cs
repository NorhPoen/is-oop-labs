namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class ProfileXmp : IPrototype<ProfileXmp>
{
    public ProfileXmp(
        string name,
        int voltage,
        int frequency)
    {
        Name = name;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Name { get; set; }
    public int Voltage { get; set; }
    public int Frequency { get; set; }

    public ProfileXmp Clone()
    {
        return new ProfileXmp(Name, Voltage, Frequency);
    }
}
