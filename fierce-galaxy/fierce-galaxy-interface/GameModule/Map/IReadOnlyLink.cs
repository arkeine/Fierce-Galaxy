using System.Collections.Generic;

namespace FierceGalaxyInterface.GameModule
{
    public interface IReadOnlyLink
    {
        IReadOnlyList<INode> Pairs
        {
            get;
        }
    }
}
