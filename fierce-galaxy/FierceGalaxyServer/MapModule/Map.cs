using FierceGalaxyInterface;
using FierceGalaxyServer.MapModule;
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

        //======================================================
        // Constructor
        //======================================================

        public Map() : this("", "") { }

        public Map(string name, string description)
        {
            listLinkedNodes = new ListLinkedNodes();
            listNode = new List<IReadOnlyNode>();
            listSpawnNode = new List<IReadOnlyNode>();

            Name = name;
            Description = description;
        }

        //======================================================
        // Override
        //======================================================

        public string Description { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<IReadOnlyNode> Nodes { get { return (IReadOnlyList<IReadOnlyNode>)listNode; } }
        public IReadOnlyList<IReadOnlyNode> SpawnNodes { get { return (IReadOnlyList<IReadOnlyNode>)listSpawnNode; } }

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
            return listLinkedNodes.LinkedNodes(source);
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
            if (!listSpawnNode.Contains((Node)node))
            {
                listSpawnNode.Add((Node)node);
            }
        }

        public bool AreNodesLinked(IReadOnlyNode n1, IReadOnlyNode n2)
        {
            return listLinkedNodes.AreNodesLinked(n1, n2);
        }
    }
}