using System;

namespace FierceGalaxyInterface.GameModule
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
