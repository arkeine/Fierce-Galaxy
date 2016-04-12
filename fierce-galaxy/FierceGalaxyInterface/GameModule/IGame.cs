using System;

namespace FierceGalaxyInterface
{
    public delegate void OnNodeUpdate(DateTime timestamp, int nodeID, IReadOnlyPlayer owner, int ressourcesOffset);
    public delegate void OnSquadLeaving(DateTime timestamp, int sourceNodeID, int targetNodeID, IReadOnlyPlayer owner, int ressources);
    public delegate void OnUpdateMana(DateTime timestamp, IReadOnlyPlayer player, int currentAmount);
    public delegate void OnGameFinish(DateTime timestamp);

    public interface IGame
    {
        event OnNodeUpdate NodeUpdateListener;
        event OnSquadLeaving SquadLeavingListener;
        event OnUpdateMana UpdateManaListener;
        event OnGameFinish GameFinishListener;

        void Move(IReadOnlyPlayer player, int sourceNodeID, int targetNodeID, int ressources);

        void UsePowerDestroy(IReadOnlyPlayer player, int targetNodeID);

        void UsePowerInvincibility(IReadOnlyPlayer player, int targetNodeID);

        void UsePowerArmor(IReadOnlyPlayer player, int targetNodeID);

        void UsePowerTeleportation(IReadOnlyPlayer player, int sourceNodeID, int targetNodeID, int ressources);
    }
}
