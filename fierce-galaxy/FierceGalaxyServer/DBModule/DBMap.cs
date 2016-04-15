using FierceGalaxyInterface;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    public class DBMap
    {
        public Nullable<int> mapID { get; set; }
        public String Name { get; set; }
        public IListLinkedNodes ListLinkedList { get; set; }
        public string Description { get; set; }
        public IList<IReadOnlyNode> ListNodes { get; set; }
        public IList<IReadOnlyNode> ListSpawnNodes { get; set; }
        IReadOnlyList<IReadOnlyNode> Nodes { get; }
        IReadOnlyList<IReadOnlyNode> SpawnNodes { get; }

        public DBMap()
        {
            mapID = null;
        }

        public DBMap(string name)
        {
            this.Name = name;
        }
    }

}