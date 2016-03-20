using fierce_galaxy_interface.fierce_galaxy_interface;
using System;

namespace fierce_galaxy_interface.text_communication
{
    /// <summary>
    /// Should be implement by class which need to throw exception asynchronly 
    /// </summary>
    public interface IErrorThrower
    {
        event EventHandler<ITextServerErrorEvent> ErrorReceive;
    }
}
