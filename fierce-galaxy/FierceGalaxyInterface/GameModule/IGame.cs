using System;

namespace FierceGalaxyInterface
{
    public delegate void NodeUpdateHandler(DateTime timestamp, IReadOnlyNode node, IReadOnlyPlayer owner, double ressourcesOffset);
    public delegate void SquadLeavesHandler(DateTime timestamp, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, IReadOnlyPlayer owner, double ressources);
    public delegate void ManaUpdateHandler(DateTime timestamp, IReadOnlyPlayer player, double currentAmount);
    public delegate void GameFinishHandler(DateTime timestamp);

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
