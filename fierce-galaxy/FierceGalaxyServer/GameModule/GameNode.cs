using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public class GameNode
    {
        public IReadOnlyPlayer CurrentOwner { get; set; }
        public IReadOnlyNode NodeData { get; set; }
    }
}
