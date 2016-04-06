using System;
using System.Collections.Generic;

namespace FierceGalaxyInterface.MapModule
{
    /// <summary>
    /// The MapManager load/save the map from/to the disk
    /// </summary>
    public interface IMapManager
    {
        IList<String> MapsName { get; }
        
        IReadOnlyMap LoadMap(String mapName);

        void SaveMap(IReadOnlyMap map);
    }
}
