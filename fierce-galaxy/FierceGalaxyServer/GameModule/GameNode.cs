using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public class GameNode
    {
        public int CurrentCapacity { get; set; }
        public IReadOnlyPlayer CurrentOwner { get; set; }
        public IReadOnlyNode NodeData { get; set; }
    }
}
