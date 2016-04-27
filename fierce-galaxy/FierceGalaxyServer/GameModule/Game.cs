using FierceGalaxyInterface;
using System;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    public class Game : IGame
    {
        //======================================================
        // Field
        //======================================================
        
        private IReadOnlyMap map;
        private INetworkTime ntp;
        private IDictionary<IReadOnlyNode, GameNode> dicGameNodeToMapNode;
        private FunctionDictionary<GameNode> nodeManager;
        private SquadManager squad

        //======================================================
        // Constructor
        //======================================================

        public Game(IReadOnlyMap map, INetworkTime ntp)
        {
            this.map = map;
            this.ntp = ntp;

            dicGameNodeToMapNode = new Dictionary<IReadOnlyNode, GameNode>();
        }

        //======================================================
        // Event
        //======================================================

        public event OnGameFinish GameFinishListener;
        public event OnNodeUpdate NodeUpdateListener;
        public event OnSquadLeaving SquadLeavingListener;
        public event OnUpdateMana UpdateManaListener;

        //======================================================
        // Override
        //======================================================

        public void Move(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, int ressources)
        {
            throw new NotImplementedException();
        }

        public void UsePowerDestroy(IReadOnlyPlayer player, IReadOnlyNode targetNode)
        {
            throw new NotImplementedException();
        }

        public void UsePowerInvincibility(IReadOnlyPlayer player, IReadOnlyNode targetNode)
        {
            throw new NotImplementedException();
        }

        public void UsePowerArmor(IReadOnlyPlayer player, IReadOnlyNode targetNode)
        {
            throw new NotImplementedException();
        }

        public void UsePowerTeleportation(IReadOnlyPlayer player, IReadOnlyNode sourceNode, IReadOnlyNode targetNode, int ressources)
        {
            throw new NotImplementedException();
        }

        //======================================================
        // Private
        //======================================================

    }
}