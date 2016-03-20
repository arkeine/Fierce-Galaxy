using System;

namespace FierceGalaxyInterface.TextCommunication
{
    /// <summary>
    /// Network server which can receive text data from a text client
    /// </summary>
    public interface ITextServer
    {
        bool initTextServer(int port);
        event EventHandler<ITextServerReceiveMessageEvent> MessageReceive;
    }
}
