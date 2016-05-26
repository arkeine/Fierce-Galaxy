using System;
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

        private Dictionary<string, Record> dictPlayers = new Dictionary<string, Record>();
        private string playerDBPath = Properties.Settings.Default.PlayerDBPath;

        //======================================================
        // Constructor
        //======================================================

        public PlayerManager()
        {
            // nothing
        }

        //======================================================
        // Override
        //======================================================

        public IReadOnlyPlayer CreatePlayer(string userName, string password, string pseudo)
        {
            if (!dictPlayers.ContainsKey(userName))
            {
                var k = new Record();
                k.PlayerObject = new Player();
                k.PlayerPassword = password;
                k.PlayerPseudo = pseudo;
                dictPlayers[userName] = k;
                SaveDataBase();
                return Login(userName, password);
            }
            else
            {
                throw new System.ArgumentException("Pseudo '" + pseudo + "' is already used", "pseudo");
            }
        }

        public void DeletePlayer(IReadOnlyPlayer player)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(IReadOnlyPlayer player)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyPlayer Login(string userName, string password)
        {
            if (dictPlayers.ContainsKey(userName))
            {
                var player = dictPlayers[userName];

                if (player.PlayerPassword == password)
                {
                    return player.PlayerObject;
                }
                else
                {
                    throw new System.ArgumentException("Password for pseudo '" + userName + "' is incorrect", "playerPW");
                }                    
            }
            else
            {
                throw new System.ArgumentException("Pseudo '" + userName + "' does not exist", "pseudo");
            }
        }

        //======================================================
        // Private
        //======================================================

        private void LoadDataBase()
        {
            foreach (var kpv in dictPlayers)
            {
                kpv.Value.PlayerObject.Invalidate();
            }

            ValidateDBExist();
            dictPlayers = JsonSerialization.ReadFromJsonFile<Dictionary<string, Record>>(playerDBPath);
        }

        private void SaveDataBase()
        {
            ValidateDBExist();
            JsonSerialization.WriteToJsonFile<Dictionary<string, Record>>(playerDBPath, dictPlayers);
        }

        private void ValidateDBExist()
        {
            var dir = Path.GetDirectoryName(playerDBPath);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            else
            { 
                // Trick to create file if not exist
                using (File.Create(playerDBPath)) { }
            }
        }


        //======================================================
        // Internal
        //======================================================

        private class Record
        {
            public Player PlayerObject { get; set; }
            public string PlayerPassword { get; set; } 
            public string PlayerPseudo { get; set; }
        }
    }
}