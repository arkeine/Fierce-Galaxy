using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    class GameNode
    {
        int CurrentCapacity { get; set; }
        IReadOnlyPlayer CurrentOwner { get; set; }
    }
}
