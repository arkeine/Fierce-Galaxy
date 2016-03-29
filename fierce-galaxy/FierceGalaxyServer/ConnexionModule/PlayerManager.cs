using FierceGalaxyInterface.ConnexionModule;
using FierceGalaxyInterface.GameModule;
using System.Collections.Generic;

namespace FierceGalaxyServer.ConnexionModule
{
    /// <summary>
    /// Singleton class
    /// Access the database to check player credentials
    /// </summary>
    public class PlayerManagement : IPlayerManagement
    {
        //======================================================
        // Field
        //======================================================

        private IDictionary<string, IPlayer> mapCachedPlayer = new Dictionary<string, IPlayer>();

        //======================================================
        // Singleton
        //======================================================

        private static PlayerManagement singleton;

        public static PlayerManagement GetInstance()
        {
            if (singleton == null)
            {
                singleton = new PlayerManagement();
            }

            return singleton;
        }

        private PlayerManagement()
        {
            // Nothing
        }

        //======================================================
        // Override
        //======================================================

        public IPlayer CreatePlayer(string playerID, string playerPW, string publicPseudo)
        {
            return Login(playerID, playerPW);
        }

        public IPlayer Login(string playerID, string playerPW)
        {
            if(IsCredentialsCorrect(playerID, playerPW))
            {
                if(!mapCachedPlayer.ContainsKey(playerID))
                {
                    mapCachedPlayer[playerID] = LoadPlayerFromDatabase(playerID);
                }
                return mapCachedPlayer[playerID];
            }
            else
            {
                return null;
            }
        }

        //======================================================
        // Private
        //======================================================

        private void CreatePlayerInDatabase(string playerID, string playerPW, string publicPseudo)
        {
            //TODO Create a player in the database with credential
        }

        private bool IsCredentialsCorrect(string playerID, string playerPW)
        {
            return false; //TODO Check if the player's credentials are correct 
        }

        private IPlayer LoadPlayerFromDatabase(string playerID)
        {
            return new Player(); //TODO Create a new player with the right datas (from database)
        }
    }
}