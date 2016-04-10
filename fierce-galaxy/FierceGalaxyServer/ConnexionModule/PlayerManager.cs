using FierceGalaxyInterface;
using FierceGalaxyServer.DBModule;
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
        
        public Dictionary<string, DBPlayer> MapDBPlayers { get; set; }

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
            dbFilePath = Properties.Settings.Default.JsonDBPath;
            //mapDBPlayers = new Dictionary<string, DBPlayer>();
            validateDBExist(dbFilePath);

            MapDBPlayers = JsonSerialization.ReadFromJsonFile<Dictionary<string, DBPlayer>>(this.dbFilePath);

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
            if (this.MapDBPlayers.ContainsKey(pseudo))
            {
                var dbplayer = MapDBPlayers[pseudo];
                if (dbplayer.playerPW == playerPW)
                {
                    var player = new Player();
                    player.PublicPseudo = dbplayer.publicPseudo;
                    return player;
                }
                else
                    throw new System.ArgumentException("Password for pseudo '" + pseudo + "' is incorrect", "playerPW");
            }
            else
                throw new System.ArgumentException("Pseudo '" + pseudo + "' does not exist", "pseudo");
        }

        //======================================================
        // Private
        //======================================================
        
        private void validateDBExist(string dbFilePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dbFilePath));
            using (StreamWriter w = File.AppendText(dbFilePath)) ;
        }

        private void CreatePlayerInDatabase(string pseudo, string playerPW, string publicPseudo)
        {
            if(MapDBPlayers.ContainsKey(pseudo))
                throw new System.ArgumentException("Pseudo '" + pseudo + "' is already used", "pseudo");
            else
            {
                DBPlayer newPlayer = new DBPlayer(MapDBPlayers.Count + 1, pseudo, playerPW, publicPseudo);
                MapDBPlayers.Add(pseudo, newPlayer);
            }
                        
            JsonSerialization.WriteToJsonFile<Dictionary<string, DBPlayer>>(dbFilePath, MapDBPlayers);
        }
    }
}