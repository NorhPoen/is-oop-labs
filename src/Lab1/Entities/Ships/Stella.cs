using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumperEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : BaseShip
{
    public Stella(bool photonicDeflector = false)
        : base(photonicDeflector)
    {
        Hull = new HullClass1();
        Deflector = new DeflectorClass1();
        ImpulsiveEngine = new EngineClassC();
        JumpEngine = new EngineOmega();
        Dimensions = BasicValues.SmallWeight;
        AntinitrineEmitter = true;
    }
}