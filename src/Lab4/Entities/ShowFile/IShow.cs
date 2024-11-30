namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ShowFile;

public interface IShow
{
    public string Mode { get; init; }
    public void Show(string text);
}