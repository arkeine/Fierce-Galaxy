using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public interface IListLinkedNodes
    {
        void AddLink(IReadOnlyNode n1, IReadOnlyNode n2);

        void RemoveLink(IReadOnlyNode n1, IReadOnlyNode n2);

        void RemoveAllLinksForNode(IReadOnlyNode n);

        bool AreNodesLinked(IReadOnlyNode n1, IReadOnlyNode n2);
    }
}
