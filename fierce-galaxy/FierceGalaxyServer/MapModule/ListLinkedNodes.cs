using FierceGalaxyInterface;
using System.Collections.Generic;

namespace FierceGalaxyServer.MapModule
{
    public class ListLinkedNodes : IListLinkedNodes
    {
        //======================================================
        // Field
        //======================================================

        private MultiMap<IReadOnlyNode, IReadOnlyNode> multiMapLinkedNodes;

        //======================================================
        // Constructor
        //======================================================

        public ListLinkedNodes()
        {
            multiMapLinkedNodes = new MultiMap<IReadOnlyNode, IReadOnlyNode>();
        }

        //======================================================
        // Override
        //======================================================

        public IReadOnlyList<IReadOnlyNode> LinkedNodes(IReadOnlyNode src)
        {
            return multiMapLinkedNodes[src];
        }

        public void AddLink(IReadOnlyNode n1, IReadOnlyNode n2)
        {
            multiMapLinkedNodes.Add(n1, n2);
            multiMapLinkedNodes.Add(n2, n1);
        }

        public bool AreNodesLinked(IReadOnlyNode n1, IReadOnlyNode n2)
        {
            return multiMapLinkedNodes.Contains(n1, n2);
        }

        public void RemoveAllLinksForNode(IReadOnlyNode n)
        {
            multiMapLinkedNodes.RemoveKey(n);

            foreach(IReadOnlyNode key in multiMapLinkedNodes.Keys)
            {
                multiMapLinkedNodes.RemoveValueInKey(key, n);
            }
        }

        public void RemoveLink(IReadOnlyNode n1, IReadOnlyNode n2)
        {
            multiMapLinkedNodes.RemoveValueInKey(n1, n2);
            multiMapLinkedNodes.RemoveValueInKey(n2, n1);
        }
    }
}