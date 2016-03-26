using System.Collections.Generic;

namespace FierceGalaxyInterface.GameModule
{
    public interface IReadOnlyMap
    {
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
