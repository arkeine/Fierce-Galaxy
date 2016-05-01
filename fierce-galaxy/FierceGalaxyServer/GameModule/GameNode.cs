using FierceGalaxyInterface;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FierceGalaxyUnitTest")]
namespace FierceGalaxyServer.GameModule
{
    class GameNode
    {
        public GameNode(IReadOnlyNode nodeDatan)
        {
            NodeData = nodeDatan;
        }

        public IReadOnlyPlayer CurrentOwner { get; set; }

        public IReadOnlyNode NodeData { get; set; }
    }
}
