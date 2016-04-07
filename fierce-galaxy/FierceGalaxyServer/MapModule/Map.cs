using FierceGalaxyInterface.MapModule;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer.MapModule
{
    public class Map : IMap
    {
        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<IReadOnlyNode> Nodes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<IReadOnlyNode> SpawnNodes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool AddLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            throw new NotImplementedException();
        }

        public bool AddNode(IReadOnlyNode node)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<IReadOnlyNode> GetLinkFrom(IReadOnlyNode source)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            throw new NotImplementedException();
        }

        public bool RemoveNode(IReadOnlyNode node)
        {
            throw new NotImplementedException();
        }

        public bool SetSpawnNode(IReadOnlyNode node, bool isSpawn)
        {
            throw new NotImplementedException();
        }
    }
}