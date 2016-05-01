using System;
using System.Net;

namespace FierceGalaxyInterface.CommunicationModule
{
    public interface ITextCommunicationServer
    {
        bool InitTextServer(int port);

        event EventHandler<IReceiveMessageEvent> MessageReceive;

        event EventHandler<Exception> ErrorOccured;
    }

    public interface IReceiveMessageEvent
    {
        IPAddress IPSource
        {
            get;
        }

        String Message
        {
            get;
        }
    }
}
