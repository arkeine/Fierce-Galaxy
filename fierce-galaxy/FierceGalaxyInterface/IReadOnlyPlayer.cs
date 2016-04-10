using System;

namespace FierceGalaxyInterface.ConnexionModule
{
    public enum Color { Red, Blue, Green, Yellow, Orange, Cyan, Purple, Pink }

    public interface IReadOnlyPlayer
    {
        String PublicPseudo { get; }

        Color Color { get; }
    }
}
