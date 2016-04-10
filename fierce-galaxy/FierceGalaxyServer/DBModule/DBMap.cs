using System;

namespace FierceGalaxyServer
{
    public class DBMap
    {
        public int mapID { get; set; }
        public String name { get; set; }

        public DBMap()
        {
        }

        public DBMap(string name)
        {
            this.name = name;
        }

        public DBMap(int mapID, string name)
        {
            this.mapID = mapID;
            this.name = name;
        }
    }
}