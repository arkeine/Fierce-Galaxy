using System;
using System.Net;

namespace FierceGalaxyInterface.CommunicationModule
{
    public interface ITextCommunicationClient
    {
        void SendMessage(IPAddress ip, int port, string message);
    }
}
