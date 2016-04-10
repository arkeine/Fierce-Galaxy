using System;

namespace FierceGalaxyInterface
{
    public interface IPlayer : IReadOnlyPlayer
    {
        new String PublicPseudo { set; get; }

        new Color Color { set; get; }
    }
}
