namespace FierceGalaxyInterface
{
    // Action to the game module

    public delegate void MoveHandler(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, double ressources);
    public delegate void UsePowerDestroyHandler(IReadOnlyPlayer player, IReadOnlyNode targetNodes);
    public delegate void UsePowerInvincibilityHandler(IReadOnlyPlayer player, IReadOnlyNode targetNode);
    public delegate void UsePowerArmorHandler(IReadOnlyPlayer player, IReadOnlyNode targetNode);
    public delegate void UsePowerTeleportationHandler(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, double ressources);

    public interface IJsonToActionParser
    {
        void Parse(string json);

        // Action to the game module

        event MoveHandler Moving;
        event UsePowerDestroyHandler UsingPowerDestroy;
        event UsePowerInvincibilityHandler UsingPowerInvincibility;
        event UsePowerArmorHandler UsingPowerArmor;
        event UsePowerTeleportationHandler UsingPowerTeleportation;
    }
}
