using System;

namespace FierceGalaxyInterface.ConnexionModule
{
    public interface IPlayer : IReadOnlyPlayer
    {   
        new String Pseudo
        {
            set;
            get;
        }

        new Color Color
        {
            set;
            get;
        }
    }
}
