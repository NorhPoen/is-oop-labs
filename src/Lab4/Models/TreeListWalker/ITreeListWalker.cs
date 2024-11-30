using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TreeListWalker;

public interface ITreeListWalker
{
    public void ShowTreeList(int depth, FileSystemManager manager);
}