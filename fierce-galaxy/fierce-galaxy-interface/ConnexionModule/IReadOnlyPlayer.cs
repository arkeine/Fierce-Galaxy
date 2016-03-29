using System;

namespace FierceGalaxyInterface.ConnexionModule
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
