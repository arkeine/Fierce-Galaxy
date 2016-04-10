using System;

namespace FierceGalaxyInterface.ConnexionModule
{
    public interface IPlayer : IReadOnlyPlayer
    {
        new String PublicPseudo { set; get; }

        new Color Color { set; get; }
    }
}
