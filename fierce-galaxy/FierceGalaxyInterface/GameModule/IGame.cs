namespace FierceGalaxyInterface
{
    public delegate void NodeUpdateHandler(IReadOnlyNode node, IReadOnlyPlayer owner, double ressourcesOffset);
    public delegate void SquadLeavesHandler(IReadOnlyNode sourceNode, IReadOnlyNode targetNode, IReadOnlyPlayer owner, double ressources);
    public delegate void ManaUpdateHandler(IReadOnlyPlayer player, double currentAmount);
    public delegate void GameFinishHandler();
    
    /// <summary>
    /// The game is a competitive round between severals players
    /// </summary>
    public interface IGame
    {
        event NodeUpdateHandler NodeUpdated;
        event SquadLeavesHandler SquadLeaves;
        event ManaUpdateHandler ManaUpdated;
        event GameFinishHandler GameFinished;

        void Move(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, double ressources);

        void UsePowerDestroy(IReadOnlyPlayer player, IReadOnlyNode targetNode);

        void UsePowerInvincibility(IReadOnlyPlayer player, IReadOnlyNode targetNode);

        void UsePowerArmor(IReadOnlyPlayer player, IReadOnlyNode targetNode);

        void UsePowerTeleportation(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, double ressources);
    }
}
