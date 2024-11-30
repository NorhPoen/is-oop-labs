using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class CasePc : IPrototype<CasePc>
{
    public CasePc(
        string name,
        int gpuMaxWidth,
        int gpuMaxHeight,
        int height,
        int wight,
        int lenght,
        IEnumerable<string> formFactors)
    {
        Name = name;
        GpuMaxWidth = gpuMaxWidth;
        GpuMaxHeight = gpuMaxHeight;
        Height = height;
        Wight = wight;
        Lenght = lenght;
        FormFactors = formFactors;
    }

    public string Name { get; set; }
    public int GpuMaxWidth { get; set; }
    public int GpuMaxHeight { get; set; }
    public int Height { get; set; }
    public int Wight { get; set; }
    public int Lenght { get; set; }
    public IEnumerable<string> FormFactors { get; set; }

    public CasePc Clone()
    {
        return new CasePc(Name, GpuMaxWidth, GpuMaxHeight, Height, Wight, Lenght, FormFactors);
    }
}
