using System;

namespace FierceGalaxyInterface.GameModule
{
    public enum Color { Red, Blue, Green, Yellow, Orange, Cyan, Purple, Pink }

    public interface IReadOnlyPlayer
    {   
        String Pseudo
        {
            get;
        }

        Color Color
        {
            get;
        }
    }
}
