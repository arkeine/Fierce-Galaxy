using System;

namespace FierceGalaxyInterface
{
    /// <summary>
    /// An invalidable object is an object "valid" 
    /// until the invalidate method is call.
    /// 
    /// Invalidable object can be share with other objects 
    /// without fear that they continu using it if no 
    /// longuer valid.
    /// </summary>
    public interface IInvalidable
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
