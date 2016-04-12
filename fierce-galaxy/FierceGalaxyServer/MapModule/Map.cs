using FierceGalaxyInterface.MapModule;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.GraphModel;

namespace FierceGalaxyServer.MapModule
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
        
        public bool AddNode(IReadOnlyNode node)
        {
            if (!ListNodes.Contains(node))
            {
                ListNodes.Add(node);
                return true;
            }
            return false;
        }

        public bool RemoveNode(IReadOnlyNode node)
        {
            if (ListNodes.Contains((Node)node))
            {
                ListNodes.Remove((Node)node);
                
                return ListLinkedList.removeAllLinksForNode(node);
            }
            return false;
        }

        public bool AddLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            if (ListNodes.Contains(node1) && ListNodes.Contains(node2))
            {
                return ListLinkedList.addLink(node1, node2);
            }
            return false;
        }

        public IReadOnlyList<IReadOnlyNode> GetLinkFrom(IReadOnlyNode source)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLink(IReadOnlyNode node1, IReadOnlyNode node2)
        {
            if (ListNodes.Contains(node1) && ListNodes.Contains(node2))
            {
                return ListLinkedList.removeLink(node1, node2);
            }
            return false;
        }

        public bool SetSpawnNode(IReadOnlyNode node, bool isSpawn)
        {
            if (!ListSpawnNodes.Contains((Node)node)){
                ListSpawnNodes.Add((Node)node);
                return true;
            }
            return false;
        }


        //======================================================
        // Private
        //======================================================
        
    }
}