using FierceGalaxyInterface;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    public class Map : IMap
    {
        //======================================================
        // Properties
        //======================================================
        
        public IListLinkedNodes ListLinkedList { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public IList<IReadOnlyNode> ListNodes { get; set; }

        public IList<IReadOnlyNode> ListSpawnNodes { get; set; }

        IReadOnlyList<IReadOnlyNode> IReadOnlyMap.Nodes { get; }

        IReadOnlyList<IReadOnlyNode> IReadOnlyMap.SpawnNodes { get; }
        
        //======================================================
        // Override
        //======================================================

        public void AddNode(IReadOnlyNode node)
        {
            if (!ListNodes.Contains(node))
            {
                ListNodes.Add(node);
            }
        }

        public void RemoveNode(IReadOnlyNode node)
        {
            if (ListNodes.Contains((Node)node))
            {
                ListNodes.Remove((Node)node);
                
                ListLinkedList.RemoveAllLinksForNode(node);
            }
        }

        public void AddLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            if (ListNodes.Contains(node1) && ListNodes.Contains(node2))
            {
                ListLinkedList.AddLink(node1, node2);
            }
        }

        public IReadOnlyList<IReadOnlyNode> GetLinkFrom(IReadOnlyNode source)
        {
            throw new NotImplementedException();
        }

        public void RemoveLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            if (ListNodes.Contains(node1) && ListNodes.Contains(node2))
            {
                ListLinkedList.RemoveLink(node1, node2);
            }
        }

        public void SetSpawnNode(IReadOnlyNode node, bool isSpawn)
        {
            if (!ListSpawnNodes.Contains((Node)node)){
                ListSpawnNodes.Add((Node)node);
            }
        }


        //======================================================
        // Private
        //======================================================
        
    }
}