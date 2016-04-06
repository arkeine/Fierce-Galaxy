using FierceGalaxyInterface.ConnexionModule;
using System;

namespace FierceGalaxyServer.ConnexionModule
{
    public class Player : IPlayer
    {
        private Color color;
        private String publicPseudo;

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

        public string PublicPseudo
        {
            get
            {
                return publicPseudo;
            }

            set
            {
                publicPseudo = value;
            }
        }
    }
}