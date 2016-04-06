using System;

namespace FierceGalaxyInterface.ConnexionModule
{
    public enum Color { Red, Blue, Green, Yellow, Orange, Cyan, Purple, Pink }

    public interface IReadOnlyPlayer
    {
        event EventHandler OnInvalidate;
        bool IsPlayervalid { get; }
        String PublicPseudo { get; }
        Color Color { get; }
    }
}
