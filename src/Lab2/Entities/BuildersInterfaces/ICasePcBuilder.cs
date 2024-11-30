using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface ICasePcBuilder
{
    ICasePcBuilder SetName(string name);
    ICasePcBuilder SetGpuMaxWidth(int gpuMaxWidth);
    ICasePcBuilder SetGpuMaxHeight(int gpuMaxHeight);
    ICasePcBuilder SetHeight(int height);
    ICasePcBuilder SetWidth(int width);
    ICasePcBuilder SetLenght(int lenght);
    ICasePcBuilder SetFormFactors(IEnumerable<string> formFactors);
    CasePc GetResult();
}