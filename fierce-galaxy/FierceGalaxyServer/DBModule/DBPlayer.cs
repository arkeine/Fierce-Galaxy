using System;
using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyServer.DBModule
{
    public class DBPlayer
    {   
        public int playerID { get; set; }
        public String pseudo { get; set; }
        public String playerPW { get; set; }
        public string publicPseudo { get; set; }
        public double score { get; set; }

        public DBPlayer()
        {

        }

        public DBPlayer(string pseudo, string playerPW, string publicPseudo = "newPlayer", double score = 0.0)
        {
            this.pseudo = pseudo;
            this.playerPW = playerPW;
            this.publicPseudo = publicPseudo;
            this.score = score;
        }

        public DBPlayer(int playerID, string pseudo, string playerPW, string publicPseudo = "newPlayer", double score = 0.0)
        {
            this.playerID = playerID;
            this.pseudo = pseudo;
            this.playerPW = playerPW;
            this.publicPseudo = publicPseudo;
            this.score = score;
        }
    }
}