using System;

namespace FierceGalaxyInterface.Communication
{
    /// <summary>
    /// Network server which can receive text data from a text client
    /// </summary>
    public interface ITextServer
    {
        bool initTextServer(int port);
        event EventHandler<ITextServerReceiveMessageEvent> MessageReceive;
        event EventHandler<ITextServerReceiveMessageEvent> ErrorOccured;
    }
}
