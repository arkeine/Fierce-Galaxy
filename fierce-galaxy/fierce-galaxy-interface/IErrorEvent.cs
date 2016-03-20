using System;

namespace FierceGalaxyInterface
{
    /// <summary>
    /// Asynchronus Error
    /// </summary>
    public interface IErrorEvent 
    {
        Exception Exception
        {
            get;
        }
    }
}
