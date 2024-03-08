using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meredian : BaseShip
{
    public Meredian(bool photonicDeflectorFlag = false)
        : base(photonicDeflectorFlag)
    {
        ImpulsiveEngine = new EngineClassE();
        Hull = new HullClass2();
        Deflector = new DeflectorClass2();
        Dimensions = BasicValues.MidWeight;
        AntinitrineEmitter = true;
    }
}