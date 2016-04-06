using FierceGalaxyInterface.ConnexionModule;
using FierceGalaxyServer.DBModule;
using System;
using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyServer.ConnexionModule
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
        
        private Dictionary<string, DBPlayer> mapDBPlayers { get; set; }
        private string dbFilePath;

        //======================================================
        // Singleton
        //======================================================

        private static PlayerManager singleton;

        public static PlayerManager GetInstance()
        {
            if (singleton == null)
            {
                singleton = new PlayerManager();
            }

            return singleton;
        }

        private PlayerManager()
        {

            dbFilePath = "C:\\temp\\dbManager.txt";
            //mapDBPlayers = new Dictionary<string, DBPlayer>();

            mapDBPlayers = JsonSerialization.ReadFromJsonFile<Dictionary<string, DBPlayer>>(this.dbFilePath);

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
            if(IsCredentialsCorrect(pseudo, playerPW))
            {
                return LoadPlayerFromDatabase(pseudo);
            }
            else
            {
                return null;
            }
        }

        //======================================================
        // Private
        //======================================================

        private void CreatePlayerInDatabase(string pseudo, string playerPW, string publicPseudo)
        {
            DBPlayer newPlayer = new DBPlayer(mapDBPlayers.Count + 1, pseudo, playerPW, publicPseudo);

            if(mapDBPlayers.ContainsKey(pseudo))
                throw new System.ArgumentException("Pseudo '" + pseudo + "' is already used", "pseudo");
            else
                mapDBPlayers.Add(pseudo, newPlayer);
                        
            JsonSerialization.WriteToJsonFile<Dictionary<string, DBPlayer>>(dbFilePath, mapDBPlayers);
        }

        private bool IsCredentialsCorrect(string pseudo, string playerPW)
        {
            if (mapDBPlayers.ContainsKey(pseudo))
            {
                var dbplayer = mapDBPlayers[pseudo];
                if (dbplayer.playerPW == playerPW)
                    return true;
            }

            return false; 
        }

        private IPlayer LoadPlayerFromDatabase(string pseudo)
        {
            if (this.mapDBPlayers.ContainsKey(pseudo))
            {
                var dbplayer = this.mapDBPlayers[pseudo];
                var player = new Player();
                player.PublicPseudo = dbplayer.publicPseudo;

                return player;
            }

            return null;
        }
    }
}