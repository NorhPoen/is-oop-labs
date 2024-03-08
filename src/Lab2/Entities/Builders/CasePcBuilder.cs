using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CasePcBuilder : ICasePcBuilder
{
    private string? _name;
    private int _gpuMaxWidth;
    private int _gpuMaxHeight;
    private int _height;
    private int _width;
    private int _lenght;
    private IEnumerable<string>? _formFactors;
    public ICasePcBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ICasePcBuilder SetGpuMaxWidth(int gpuMaxWidth)
    {
        _gpuMaxWidth = gpuMaxWidth;
        return this;
    }

    public ICasePcBuilder SetGpuMaxHeight(int gpuMaxHeight)
    {
        _gpuMaxHeight = gpuMaxHeight;
        return this;
    }

    public ICasePcBuilder SetHeight(int height)
    {
        _height = height;
        return this;
    }

    public ICasePcBuilder SetWidth(int width)
    {
        _width = width;
        return this;
    }

    public ICasePcBuilder SetLenght(int lenght)
    {
        _lenght = lenght;
        return this;
    }

    public ICasePcBuilder SetFormFactors(IEnumerable<string> formFactors)
    {
        _formFactors = formFactors;
        return this;
    }

    public CasePc GetResult()
    {
        if (_name is not null && _formFactors is not null)
        {
            return new CasePc(_name, _gpuMaxWidth, _gpuMaxHeight, _height, _width, _lenght, _formFactors);
        }

        throw new ArgumentException("Field is null");
    }
}
