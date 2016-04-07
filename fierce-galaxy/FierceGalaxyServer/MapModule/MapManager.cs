using FierceGalaxyInterface.MapModule;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer.MapModule
{
    public class MapManager : IMapManager
    {
        public IList<string> MapsName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyMap LoadMap(string mapName)
        {
            throw new NotImplementedException();
        }

        public void SaveMap(IReadOnlyMap map)
        {
            throw new NotImplementedException();
        }
    }
}