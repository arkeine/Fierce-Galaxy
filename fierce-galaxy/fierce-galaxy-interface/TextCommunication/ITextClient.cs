using System;
using System.Net;

namespace FierceGalaxyInterface.Communication
{
    /// <summary>
    /// Network client which can send text data to a text server
    /// </summary>
    public interface ITextClient
    {
        void sendMessage(IPAddress ip, int port, String message);
    }
}
