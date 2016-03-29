using FierceGalaxyInterface.GameModule;
using System;

namespace FierceGalaxyServer.ConnexionModule
{
    public class Player : IPlayer
    {
        private Color color;
        private String pseudo;

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public string Pseudo
        {
            get
            {
                return pseudo;
            }

            set
            {
                pseudo = value;
            }
        }
    }
}