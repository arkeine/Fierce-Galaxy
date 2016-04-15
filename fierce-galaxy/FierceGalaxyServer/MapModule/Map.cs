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

        private IListLinkedNodes listLinkedNodes;
        private IList<IReadOnlyNode> listNode;
        private IList<IReadOnlyNode> listSpawnNode;

        public Map()
        {
            listLinkedNodes = new ListLinkedNodes();
            listNode = new List<IReadOnlyNode>();
            listSpawnNode = new List<IReadOnlyNode>();
        }
        //======================================================
        // Override
        //======================================================

        public string Description { get; set; }
        public string Name { get; set; }
        IReadOnlyList<IReadOnlyNode> IReadOnlyMap.Nodes { get; }
        IReadOnlyList<IReadOnlyNode> IReadOnlyMap.SpawnNodes { get; }

        public void AddNode(IReadOnlyNode node)
        {
            if (!listNode.Contains(node))
            {
                listNode.Add(node);
            }
        }

        public void RemoveNode(IReadOnlyNode node)
        {
            if (listNode.Contains(node))
            {
                listNode.Remove(node);
                
                listLinkedNodes.RemoveAllLinksForNode(node);
            }
        }

        public void AddLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            if (listNode.Contains(node1) && listNode.Contains(node2))
            {
                listLinkedNodes.AddLink(node1, node2);
            }
        }

        public IReadOnlyList<IReadOnlyNode> GetLinkFrom(IReadOnlyNode source)
        {
            throw new NotImplementedException();
        }

        public void RemoveLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            if (listNode.Contains(node1) && listNode.Contains(node2))
            {
                listLinkedNodes.RemoveLink(node1, node2);
            }
        }

        public void SetSpawnNode(IReadOnlyNode node, bool isSpawn)
        {
            if (!listSpawnNode.Contains((Node)node)){
                listSpawnNode.Add((Node)node);
            }
        }


        //======================================================
        // Private
        //======================================================
        
    }
}