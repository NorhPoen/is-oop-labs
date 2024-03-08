using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumperEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Augur : BaseShip
{
    public Augur(bool photonicDeflectorFlag = false)
        : base(photonicDeflectorFlag)
    {
        ImpulsiveEngine = new EngineClassE();
        Hull = new HullClass3();
        Deflector = new DeflectorClass3();
        JumpEngine = new EngineAlpha();
        Dimensions = BasicValues.BigWeight;
        AntinitrineEmitter = false;
    }
}