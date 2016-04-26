using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyServer
{
    public class DBJsonManager : IDBPlayerManager, IDBMapManager
    {
        //======================================================
        // Field
        //======================================================

        private DBJson dbPlayersJson;
        private DBJson dbMapsJson;
        private string dbPlayersFile;
        private string dbMapsPath;

        //======================================================
        // Constructor
        //======================================================

        public DBJsonManager()
        {
            string dbFilePath = Properties.Settings.Default.JsonDBPath;
            string dbPlayersFileName = Properties.Settings.Default.JsonDBPlayersFileName;

            dbPlayersFile = dbFilePath + dbPlayersFileName;
            dbMapsPath = dbFilePath + Properties.Settings.Default.JsonDBMapsPath;

            ValidateDBExist();
            LoadPlayersDB();
            //LoadMapsDB();
        }

        //======================================================
        // Override
        //======================================================

        public bool ContainsPlayer(string key)
        {
            return dbPlayersJson.DicDBPlayers.ContainsKey(key);
        }

        public void SetPlayer(string key, DBPlayer player)
        {
            if(player.playerID == null)
            {
                player.playerID = dbPlayersJson.CurrentID++;
            }
            dbPlayersJson.DicDBPlayers[key] = player;
            SaveDB();
        }

        public DBPlayer GetPlayer(string key)
        {
            DBPlayer p;
            dbPlayersJson.DicDBPlayers.TryGetValue(key, out p);
            return p;
        }
        
        public DBMap GetMap(string key)
        {
            DBMap m;
            dbPlayersJson.DicDBMaps.TryGetValue(key, out m);
            return m;
        }

        public bool ContainsMap(string key)
        {
            return dbPlayersJson.DicDBMaps.ContainsKey(key);
        }

        public void SetMap(string key, DBMap map)
        {
            if (map.mapID == null)
            {
                map.mapID = dbPlayersJson.CurrentID++;
            }
            dbPlayersJson.DicDBMaps[key] = map;
            SaveDB();
        }

        //======================================================
        // Private
        //======================================================

        private void SaveDB()
        {
            string jsonDBPath = Properties.Settings.Default.JsonDBPath;
            string jsonDBPlayersFileName = Properties.Settings.Default.JsonDBPlayersFileName;
            JsonSerialization.WriteToJsonFile<DBJson>
                (jsonDBPath + jsonDBPlayersFileName, dbPlayersJson);
        }

        private void LoadPlayersDB()
        {
            dbPlayersJson = JsonSerialization.ReadFromJsonFile<DBJson>(dbPlayersFile);
        }

        private void ValidateDBExist()
        {
            FileInfo fileInfo = new FileInfo(dbPlayersFile);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);

            // Trick to create file if not exist
            using (File.Create(dbPlayersFile)) { }
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