using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FierceGalaxyServer
{
    public class Game : IGame
    {
        //======================================================
        // Field
        //======================================================
        
        private IReadOnlyMap map;
        private INetworkTime ntp;
        private IDictionary<IReadOnlyNode, Int32> dicNodeValueOffset;

        //======================================================
        // Constructor
        //======================================================

        public Game(IReadOnlyMap map, INetworkTime ntp)
        {
            this.map = map;
            this.ntp = ntp;

            dicNodeValueOffset = new Dictionary<IReadOnlyNode, Int32>();
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

        public void Move(IReadOnlyPlayer player, int sourceNodeID, int targetNodeID, int ressources)
        {
            // Take ressources from node

        }

        public void UsePowerArmor(IReadOnlyPlayer player, int targetNodeID)
        {
            throw new NotImplementedException();
        }

        public void UsePowerDestroy(IReadOnlyPlayer player, int targetNodeID)
        {
            throw new NotImplementedException();
        }

        public void UsePowerInvincibility(IReadOnlyPlayer player, int targetNodeID)
        {
            throw new NotImplementedException();
        }

        public void UsePowerTeleportation(IReadOnlyPlayer player, int sourceNodeID, int targetNodeID, int ressources)
        {
            throw new NotImplementedException();
        }

        //======================================================
        // Private
        //======================================================
        
        
    }
}