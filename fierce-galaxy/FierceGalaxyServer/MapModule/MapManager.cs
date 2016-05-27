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
        private const string extention = ".json";
        private string mapsDBPath;

        //======================================================
        // Constructor
        //======================================================
        
        public MapManager(string mapsDBPath)
        {
            dicMaps = new Dictionary<string, IReadOnlyMap>();
            this.mapsDBPath = mapsDBPath;

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
            Directory.CreateDirectory(mapsDBPath); 

            dicMaps = new Dictionary<string, IReadOnlyMap>();

            string[] pathEntries = Directory.GetFiles(mapsDBPath);
            foreach (string pathName in pathEntries)
            {
                var map = JsonSerialization.ReadFromJsonFile<Map>(pathName);                
                dicMaps.Add(Path.GetFileNameWithoutExtension(pathName), map);
            }
        }

        public void SaveMap(Map map)
        {
            Directory.CreateDirectory(mapsDBPath);

            if (!dicMaps.ContainsKey(map.Name))
            {
                if(map.Name != "")
                {
                    JsonSerialization.WriteToJsonFile<Map>
                        (mapsDBPath + Path.DirectorySeparatorChar + map.Name + extention, map);

                    LoadMaps();
                    foreach(var v in dicMaps)
                    {
                        Console.WriteLine(v.Key);
                    }
                }
                else
                {
                    throw new ArgumentException("Parameter 'Name' cannot be null");
                }
            }
            else
            {
                throw new ArgumentException("Map name already exist", "map.Name");
            }
        }
    }
}