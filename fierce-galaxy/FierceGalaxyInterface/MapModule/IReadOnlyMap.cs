using System.Collections.Generic;

namespace FierceGalaxyInterface.MapModule
{
    public interface IReadOnlyMap
    {
        /// <summary>
        /// Return the nodes acessible from the source node
        /// </summary>
        IReadOnlyList<IReadOnlyNode> GetLinkFrom(IReadOnlyNode source);

        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        IReadOnlyList<IReadOnlyNode> SpawnNodes
        {
            get;
        }

        IReadOnlyList<IReadOnlyNode> Nodes
        {
            get;
        }
    }
}
