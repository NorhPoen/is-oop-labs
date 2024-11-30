using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public interface IBuildComponentDb<T>
{
    IList<T> BuildComponentDb();
    IList<T> AddNewComponent(IList<T> newComponents);
}