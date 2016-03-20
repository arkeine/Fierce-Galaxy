using fierce_galaxy_interface.text_communication;
using System;

namespace fierce_galaxy_interface.fierce_galaxy_interface
{
    public interface ITextServerErrorEvent : ITextServerEvent
    {
        Exception Exception
        {
            get;
        }
    }
}
