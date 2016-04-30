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
        private SquadManager squadManager;
        private IDictionary<IReadOnlyNode, IReadOnlyPlayer> spawnAttribution;

        //======================================================
        // Constructor
        //======================================================

        public Game(IReadOnlyMap map, INetworkTime ntp, 
            IDictionary<IReadOnlyNode, IReadOnlyPlayer> spawnAttribution)
        {
            this.map = map;
            this.ntp = ntp;
            this.spawnAttribution = spawnAttribution;

            dicGameNodeToMapNode = new Dictionary<IReadOnlyNode, GameNode>();
            nodeManager = new FunctionDictionary<GameNode>();
            squadManager = new SquadManager(nodeManager);

            LoadMap(map);
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

        private void LoadMap(IReadOnlyMap map)
        {
            foreach(IReadOnlyNode n in map.Nodes)
            {
                GameNode gn = new GameNode(n);

                if(spawnAttribution.ContainsKey(n))
                {

                }

                dicGameNodeToMapNode.Add(n, gn);
            }            
        }

    }
}