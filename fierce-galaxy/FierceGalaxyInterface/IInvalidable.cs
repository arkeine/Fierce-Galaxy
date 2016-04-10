using System;

namespace FierceGalaxyInterface
{
    interface IInvalidable
    {
        event EventHandler OnInvalidate;

        /// <summary>
        /// When a player is invalidate, it send a event to all listener.
        /// This event mean the listener shoult stop to use it.
        /// </summary>
        void Invalidate();

        bool IsValid { get; }
    }
}
