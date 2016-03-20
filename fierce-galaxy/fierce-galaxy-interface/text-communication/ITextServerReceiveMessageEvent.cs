using System;
using System.Net;

namespace fierce_galaxy_interface.fierce_galaxy_interface
{
    /// <summary>
    /// Event emit when the text server receive a message from the text client
    /// </summary>
    public interface ITextServerReceiveMessageEvent 
    {
        String Message
        {
            get;
        }

        IPAddress IPSource
        {
            get;
        }
    }
}
