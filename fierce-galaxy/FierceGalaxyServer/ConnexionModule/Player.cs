using FierceGalaxyInterface;
using System;

namespace FierceGalaxyServer.ConnexionModule
{
    public class Player : IPlayer, IInvalidable
    {
        //======================================================
        // Field
        //======================================================

        private Color color;
        private String publicPseudo = "";
        private bool valid = true;

        //======================================================
        // Override
        //======================================================

        public event EventHandler OnInvalidate;

        public bool IsValid
        {
            get
            {
                return valid;
            }
        }
        public void Invalidate()
        {
            valid = false;
        }

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