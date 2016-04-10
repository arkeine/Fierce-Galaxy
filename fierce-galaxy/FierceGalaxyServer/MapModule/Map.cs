using FierceGalaxyInterface;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    public class Map : IMap
    {
        //======================================================
        // Field
        //======================================================
        
        private string name;
        private string description;
        private List<Node> listNodes;
        private List<Node> listSpawnNodes;

        //======================================================
        // Override
        //======================================================

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public IReadOnlyList<IReadOnlyNode> Nodes
        {
            get
            {
                return (IReadOnlyList<Node>)listNodes;
            }
        }

        public IReadOnlyList<IReadOnlyNode> SpawnNodes
        {
            get
            {
                return (IReadOnlyList<Node>)listSpawnNodes;
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


        //======================================================
        // Private
        //======================================================

    }
}