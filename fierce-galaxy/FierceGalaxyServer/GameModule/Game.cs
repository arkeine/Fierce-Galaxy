﻿using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FierceGalaxyServer
{
    public class Game : IGame
    {
        //======================================================
        // Field
        //======================================================
        
        private IReadOnlyMap map;
        private IDictionary<IReadOnlyNode, IReadOnlyPlayer> spawnAttribution;
        private IDictionary<IReadOnlyNode, GameNode> dicGameNodeToMapNode;
        private FunctionDictionary<GameNode> nodeManager;
        private SquadManager squadManager;
        private TimestampManager timestamp;

        //======================================================
        // Constructor
        //======================================================

        public Game(IReadOnlyMap map, IDictionary<IReadOnlyNode,
            IReadOnlyPlayer> spawnAttribution)
        {
            this.map = map;
            this.spawnAttribution = spawnAttribution;

            timestamp = new TimestampManager(new NetworkTime());
            dicGameNodeToMapNode = new Dictionary<IReadOnlyNode, GameNode>();
            nodeManager = new FunctionDictionary<GameNode>();
            squadManager = new SquadManager(nodeManager);

            LoadMap(map);
            squadManager.NodeUpdated += OnNodeUpdate;
            squadManager.SquadLeaves += OnSquadLeaves;
        }

        //======================================================
        // Event
        //======================================================

        public event GameFinishHandler GameFinished;
        public event NodeUpdateHandler NodeUpdated;
        public event SquadLeavesHandler SquadLeaves;
        public event ManaUpdateHandler ManaUpdated;

        private void OnGameFinish()
        {
            if (GameFinished != null) GameFinished(timestamp.GetNetworkTimeStamp());
        }

        private void OnNodeUpdate(GameNode n)
        {
            if (NodeUpdated != null) NodeUpdated(timestamp.GetNetworkTimeStamp(), 
                n.NodeData, n.CurrentOwner, nodeManager.GetCurrentOffset(n));
        }

        private void OnSquadLeaves(GameNode source, GameNode target, IReadOnlyPlayer owner, double ressources)
        {
            if (SquadLeaves != null) SquadLeaves(timestamp.GetNetworkTimeStamp(),
                source.NodeData, target.NodeData, owner, ressources);
        }

        private void OnManaUpdate()
        {
            throw new NotImplementedException();
        }

        //======================================================
        // Override
        //======================================================

        public void Move(IReadOnlyPlayer player, IReadOnlyNode sourceNode, 
            IReadOnlyNode targetNode, double ressources)
        {
            GameNode gnSource = dicGameNodeToMapNode[sourceNode];
            GameNode gnTarget = dicGameNodeToMapNode[targetNode];

            if (gnSource.CurrentOwner == player &&
                map.GetLinkFrom(sourceNode).Contains(targetNode))
            {
                squadManager.SendSquad(ressources, gnSource, gnTarget);
            }
        }

        public void UsePowerDestroy(IReadOnlyPlayer player,
            IReadOnlyNode targetNode)
        {
            throw new NotImplementedException();
        }

        public void UsePowerInvincibility(IReadOnlyPlayer player,
            IReadOnlyNode targetNode)
        {
            throw new NotImplementedException();
        }

        public void UsePowerArmor(IReadOnlyPlayer player,
            IReadOnlyNode targetNode)
        {
            throw new NotImplementedException();
        }

        public void UsePowerTeleportation(IReadOnlyPlayer player,
            IReadOnlyNode sourceNode, IReadOnlyNode targetNode, double ressources)
        {
            throw new NotImplementedException();
        }

        //======================================================
        // Private
        //======================================================

        private void LoadMap(IReadOnlyMap map)
        {
            if(spawnAttribution.Count > map.SpawnNodes.Count)
            {
                throw new ArgumentException("Too many players for this map");
            }

            foreach(IReadOnlyNode n in map.Nodes)
            {
                GameNode gn = new GameNode(n);

                if (spawnAttribution.ContainsKey(n))
                {
                    if (map.SpawnNodes.Contains(n))
                    {
                        gn.CurrentOwner = spawnAttribution[n];
                    }
                    else
                    {
                        throw new ArgumentException("Spawn attribution is not correct");
                    }
                }
                
                dicGameNodeToMapNode.Add(n, gn);
            }            
        }

    }
}