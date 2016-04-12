using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyServer
{
    public class DBJsonManager : IDBManager
    {
        //======================================================
        // Field
        //======================================================

        private DBJson dbJson;
        private string dbFilePath;

        //======================================================
        // Constructor
        //======================================================

        public DBJsonManager(string dbFilePath)
        {
            this.dbFilePath = dbFilePath;
            ValidateDBExist();
            LoadDB();
        }

        //======================================================
        // Access
        //======================================================

        public bool ContainsPlayer(string key)
        {
            return dbJson.MapDBPlayers.ContainsKey(key);
        }

        public void SetPlayer(string key, DBPlayer player)
        {
            if(player.playerID == null)
            {
                player.playerID = dbJson.CurrentID++;
            }
            dbJson.MapDBPlayers[key] = player;
            SaveDB();
        }

        public DBPlayer GetPlayer(string key)
        {
            DBPlayer p;
            dbJson.MapDBPlayers.TryGetValue(key, out p);
            return p;
        }        

        //======================================================
        // Private
        //======================================================

        private void SaveDB()
        {
            JsonSerialization.WriteToJsonFile<DBJson>
                (Properties.Settings.Default.JsonDBPath, dbJson);
        }

        private void LoadDB()
        {
            dbJson = JsonSerialization.ReadFromJsonFile<DBJson>(dbFilePath);
        }

        private void ValidateDBExist()
        {
            FileInfo fileInfo = new FileInfo(dbFilePath);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);

            // Trick to create file if not exist
            using (File.Create(dbFilePath)) { }
        }

        //======================================================
        // Internal
        //======================================================

        class DBJson
        {
            public Dictionary<string, DBPlayer> MapDBPlayers { get; set; }
            public int CurrentID { get; set; }

            public DBJson()
            {
                MapDBPlayers = new Dictionary<string, DBPlayer>();
                CurrentID = 0;
            }
        }
    }
}