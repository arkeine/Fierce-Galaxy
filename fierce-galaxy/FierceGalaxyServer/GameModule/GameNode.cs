using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public class GameNode
    {
        public GameNode(IReadOnlyNode nodeDatan)
        {
            NodeData = nodeDatan;
        }

        public IReadOnlyPlayer CurrentOwner { get; set; }
        public IReadOnlyNode NodeData { get; set; }
    }
}
