using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FierceGalaxyServer
{
    public class MapManager
    {
        //======================================================
        // Field
        //======================================================

        private IDictionary<string, IReadOnlyMap> dicMaps;
        private const string extention = ".json";
        private string mapsDBPath;

        //======================================================
        // Constructor
        //======================================================

        public MapManager()
        {
            dicMaps = new Dictionary<string, IReadOnlyMap>();
            mapsDBPath = Properties.Settings.Default.MapsDBPath;

            Console.WriteLine(mapsDBPath);
            Directory.CreateDirectory(mapsDBPath);

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
            dicMaps = new Dictionary<string, IReadOnlyMap>();

            string[] fileEntries = Directory.GetFiles(mapsDBPath);
            foreach (string fileName in fileEntries)
            {
                Console.WriteLine(fileName);
                var map = JsonSerialization.ReadFromJsonFile<Map>(fileName);
                dicMaps.Add(fileName, map);
            }
        }

        public void SaveMap(Map map)
        {
            if (dicMaps.ContainsKey(map.Name))
            {
                if(map.Name != "")
                {
                    JsonSerialization.WriteToJsonFile<Map>
                        (mapsDBPath + Path.DirectorySeparatorChar + map.Name + extention, map);

                    LoadMaps();
                }
                else
                {
                    throw new System.ArgumentException("Parameter 'Name' cannot be null");
                }
            }
            else
            {
                throw new System.ArgumentException("Map name already exist", "map.Name");
            }
        }
    }
}