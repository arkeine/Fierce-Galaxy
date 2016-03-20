using System;
using System.Net;

namespace fierce_galaxy_interface.text_communication
{
    public interface ITextClient
    {
        void sendMessage(IPAddress ip, int port, String message);
    }
}
