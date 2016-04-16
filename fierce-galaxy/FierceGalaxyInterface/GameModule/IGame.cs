using System;

namespace FierceGalaxyInterface
{
    public delegate void OnNodeUpdate(DateTime timestamp, IReadOnlyNode node, IReadOnlyPlayer owner, int ressourcesOffset);
    public delegate void OnSquadLeaving(DateTime timestamp, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, IReadOnlyPlayer owner, int ressources);
    public delegate void OnUpdateMana(DateTime timestamp, IReadOnlyPlayer player, int currentAmount);
    public delegate void OnGameFinish(DateTime timestamp);

    public interface IGame
    {
        event OnNodeUpdate NodeUpdateListener;
        event OnSquadLeaving SquadLeavingListener;
        event OnUpdateMana UpdateManaListener;
        event OnGameFinish GameFinishListener;

        void Move(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, int ressources);

        void UsePowerDestroy(IReadOnlyPlayer player, IReadOnlyNode targetNode);

        void UsePowerInvincibility(IReadOnlyPlayer player, IReadOnlyNode targetNode);

        void UsePowerArmor(IReadOnlyPlayer player, IReadOnlyNode targetNode);

        void UsePowerTeleportation(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, int ressources);
    }
}
