
using System;

namespace FierceGalaxyInterface
{
    /// <summary>
    /// Should be implement by classes which need to throw exception asynchronly 
    /// </summary>
    public interface IErrorThrower
    {
        event EventHandler<IErrorEvent> ErrorReceive;
    }
}
