using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyServer
{
    public class MapManager
    {
        //======================================================
        // Field
        //======================================================

        private IDictionary<string, IReadOnlyMap> dicMaps;
        private string dbFilePath;
        private string mapsDirectory;
        private DBMap dbMapJson;

        //======================================================
        // Constructor
        //======================================================

        public MapManager()
        {
            dicMaps = new Dictionary<string, IReadOnlyMap>();

            dbFilePath = Properties.Settings.Default.JsonDBPath;

            mapsDirectory = dbFilePath + Properties.Settings.Default.JsonDBMapsPath;

            LoadMaps();
        }

        //======================================================
        // Override
        //======================================================

        public IReadOnlyList<string> ListMap()
        {
            throw new NotImplementedException();
        }

        public void LoadMaps()
        {
            Directory.CreateDirectory(mapsDirectory);
            string[] fileEntries = Directory.GetFiles(mapsDirectory);
            foreach (string fileName in fileEntries)
            {
                dbMapJson = JsonSerialization.ReadFromJsonFile<DBMap>(fileName);
                var map = new Map(dbMapJson.Name, dbMapJson.Description);
                dicMaps.Add(dbMapJson.Name, map);
            }
        }

        public void SaveMap(DBMap map)
        {
            Console.Write(mapsDirectory + map.Name);
            JsonSerialization.WriteToJsonFile<DBMap>
                (mapsDirectory + "\\" + map.Name + ".json", map);
        }

        //======================================================
        // Private
        //======================================================
        
        private IReadOnlyMap LoadSingleMap(string mapName)
        {
            IReadOnlyMap m = JsonSerialization.ReadFromJsonFile<Map>(
                mapsDirectory + mapName);
            return m;
        }
    }
}