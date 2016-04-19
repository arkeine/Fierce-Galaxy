using FierceGalaxyInterface;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    public class MapManager : IMapManager
    {
        //======================================================
        // Field
        //======================================================

        private IDBMapManager dBMapManager;

        //======================================================
        // Constructor
        //======================================================

        public MapManager(IDBPlayerManager dBMapManager)
        {
            dBMapManager = dBMapManager;
        }

        //======================================================
        // Override
        //======================================================

        public IList<string> MapsName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyMap LoadMap(string mapName)
        {
            if (dBMapManager.ContainsMap(mapName))
            {
                var dbMap = dBMapManager.GetMap(mapName);
                var map = new Map();
                map.Name = dbMap.Name;
                map.Description = dbMap.Description;
                return map;
            }
            else
            {
                return null;
                //throw new System.ArgumentException("Pseudo '" + pseudo + "' does not exist", "pseudo");
            }
        }

        public void SaveMap(IReadOnlyMap map)
        {
            throw new NotImplementedException();
        }

        //======================================================
        // Private
        //======================================================
        
    }
}