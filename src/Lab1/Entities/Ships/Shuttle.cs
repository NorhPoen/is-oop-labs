using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : BaseShip
{
    public Shuttle(bool photonicDeflectorFlag = false)
        : base(photonicDeflectorFlag)
    {
        ImpulsiveEngine = new EngineClassC();
        Hull = new HullClass1();
        Dimensions = BasicValues.SmallWeight;
        AntinitrineEmitter = false;
    }
}