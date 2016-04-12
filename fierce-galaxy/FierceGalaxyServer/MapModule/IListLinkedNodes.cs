using FierceGalaxyInterface;

namespace FierceGalaxyServer.MapModule
{
    public interface IListLinkedNodes
    {
        // return false if link already exist
        bool addLink(IReadOnlyNode n1, IReadOnlyNode n2);

        // return false if link does not exist
        bool removeLink(IReadOnlyNode n1, IReadOnlyNode n2);

        bool removeAllLinksForNode(IReadOnlyNode n);
        //TODO
    }
}
