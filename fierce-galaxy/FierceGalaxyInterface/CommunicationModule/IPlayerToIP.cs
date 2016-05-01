using System;

namespace FierceGalaxyInterface.ParserModule
{
    public interface IPlayerToIP
    {
        void SendMessage(IReadOnlyPlayer player, string message);

        event EventHandler<IReceiveMessageEvent> MessageReceive;
    }

    public interface IReceiveMessageEvent
    {
        IReadOnlyPlayer Player
        {
            get;
        }

        String Message
        {
            get;
        }
    }
}
