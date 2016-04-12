using System;

namespace FierceGalaxyServer
{
    public class DBPlayer
    {   
        public Nullable<int> playerID { get; set; }
        public String pseudo { get; set; }
        public String playerPW { get; set; }
        public string publicPseudo { get; set; }
        public double score { get; set; }

        public DBPlayer()
        {
            playerID = null;
        }

        public DBPlayer(string pseudo, string playerPW, string publicPseudo = "newPlayer", double score = 0.0)
        {
            this.pseudo = pseudo;
            this.playerPW = playerPW;
            this.publicPseudo = publicPseudo;
            this.score = score;
        }
    }
}