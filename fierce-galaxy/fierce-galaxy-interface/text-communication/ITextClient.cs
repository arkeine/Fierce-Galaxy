using System;
using System.Net;

namespace fierce_galaxy_interface.text_communication
{
    /// <summary>
    /// Network client which can send text data to a text server
    /// </summary>
    public interface ITextClient
    {
        void sendMessage(IPAddress ip, int port, String message);
    }
}
