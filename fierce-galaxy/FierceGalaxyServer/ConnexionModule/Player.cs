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

        public bool IsPlayervalid
        {
            get
            {
                throw new NotImplementedException();
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

        public event EventHandler OnInvalidate;

        public void Invalidate()
        {
            throw new NotImplementedException();
        }
    }
}