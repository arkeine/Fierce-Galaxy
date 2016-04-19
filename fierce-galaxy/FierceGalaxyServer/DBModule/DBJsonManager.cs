using System;
using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyServer
{
    public class DBJsonManager : IDBPlayerManager, IDBMapManager
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
        // Override
        //======================================================

        public bool ContainsPlayer(string key)
        {
            return dbJson.DicDBPlayers.ContainsKey(key);
        }

        public void SetPlayer(string key, DBPlayer player)
        {
            if(player.playerID == null)
            {
                player.playerID = dbJson.CurrentID++;
            }
            dbJson.DicDBPlayers[key] = player;
            SaveDB();
        }

        public DBPlayer GetPlayer(string key)
        {
            DBPlayer p;
            dbJson.DicDBPlayers.TryGetValue(key, out p);
            return p;
        }
        
        public DBMap GetMap(string key)
        {
            DBMap m;
            dbJson.DicDBMaps.TryGetValue(key, out m);
            return m;
        }

        public bool ContainsMap(string key)
        {
            return dbJson.DicDBMaps.ContainsKey(key);
        }

        public void SetMap(string key, DBMap map)
        {
            if (map.mapID == null)
            {
                map.mapID = dbJson.CurrentID++;
            }
            dbJson.DicDBMaps[key] = map;
            SaveDB();
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
            public Dictionary<string, DBPlayer> DicDBPlayers { get; set; }
            public Dictionary<string, DBMap> DicDBMaps { get; set; }
            public int CurrentID { get; set; }

            public DBJson()
            {
                DicDBPlayers = new Dictionary<string, DBPlayer>();
                DicDBMaps = new Dictionary<string, DBMap>();
                CurrentID = 0;
            }
        }
    }
}