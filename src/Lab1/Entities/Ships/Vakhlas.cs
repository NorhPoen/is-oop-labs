using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumperEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vakhlas : BaseShip
{
    public Vakhlas(bool photonicDeflectorFlag = false)
        : base(photonicDeflectorFlag)
    {
        ImpulsiveEngine = new EngineClassE();
        JumpEngine = new EngineGamma();
        Hull = new HullClass2();
        Deflector = new DeflectorClass1();
        Dimensions = BasicValues.MidWeight;
        AntinitrineEmitter = false;
    }
}