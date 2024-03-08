using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildersInterfaces;

public interface IRamBuilder
{
    IRamBuilder SetName(string name);
    IRamBuilder SetCapacity(int capacity);
    IRamBuilder SetFrequency(int frequency);
    IRamBuilder SetXmps(IEnumerable<string> xmps);
    IRamBuilder SetFormFactor(string formFactor);
    IRamBuilder SetDdrStandart(string ddrStandart);
    IRamBuilder SetWattage(int wattage);
    Ram GetResult();
}