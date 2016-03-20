using System;

namespace fierce_galaxy_interface.fierce_galaxy_interface
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
