using System;

namespace fierce_galaxy_interface.fierce_galaxy_interface
{
    public interface ITextServer
    {
        bool initTextServer(int port);
        event EventHandler<ITextServerReceiveMessageEvent> MessageReceive;
    }
}
