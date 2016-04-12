using FierceGalaxyInterface;
using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyServer
{
    /// <summary>
    /// Singleton class
    /// Access the database to check player credentials
    /// </summary>
    public class PlayerManager : IPlayerManager
    {
        //======================================================
        // Field
        //======================================================
        
        private IDBManager dBManager;

        //======================================================
        // Constructor
        //======================================================

        public PlayerManager(IDBManager dBManager)
        {
            this.dBManager = dBManager;
        }

        //======================================================
        // Override
        //======================================================

        public IPlayer CreatePlayer(string pseudo, string playerPW, string publicPseudo)
        {
            CreatePlayerInDatabase(pseudo, playerPW, publicPseudo);
            return Login(pseudo, playerPW);
        }

        public IPlayer Login(string pseudo, string playerPW)
        {
            if (dBManager.ContainsPlayer(pseudo))
            {
                var dbPlayer = dBManager.GetPlayer(pseudo);

                if (dbPlayer.playerPW == playerPW)
                {
                    return CreatePlayerFromDBPlayer(dbPlayer);
                }
                else
                {
                    throw new System.ArgumentException("Password for pseudo '" + pseudo + "' is incorrect", "playerPW");
                }                    
            }
            else
            {
                throw new System.ArgumentException("Pseudo '" + pseudo + "' does not exist", "pseudo");
            }
        }

        //======================================================
        // Private
        //======================================================
        
        private IPlayer CreatePlayerFromDBPlayer(DBPlayer dbPlayer)
        {
            var player = new Player();
            player.PublicPseudo = dbPlayer.publicPseudo;
            return player;
        }

        private void CreatePlayerInDatabase(string pseudo, string playerPW, string publicPseudo)
        {
            if(!dBManager.ContainsPlayer(pseudo))
            {
                DBPlayer newPlayer = new DBPlayer(pseudo, playerPW, publicPseudo);
                dBManager.SetPlayer(pseudo, newPlayer);
            }
            else
            {
                throw new System.ArgumentException("Pseudo '" + pseudo + "' is already used", "pseudo");
            }
        }
    }
}