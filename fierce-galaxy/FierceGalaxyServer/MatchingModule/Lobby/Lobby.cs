using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FierceGalaxyServer
{
    public class Lobby : ILobby
    {
        //======================================================
        // Field
        //======================================================

        //private IList<GamePlayer> listPlayers;
        private IDictionary<IReadOnlyPlayer, GamePlayer> dictPlayers;
        private IReadOnlyMap currentMap;
        private GamePlayer owner;
        private string name;

        //======================================================
        // Constructor
        //======================================================
        
        public Lobby(string lobbyName, IReadOnlyPlayer gameOwner)
        {
            dictPlayers = new Dictionary<IReadOnlyPlayer, GamePlayer>();
            owner = new GamePlayer(gameOwner);
            name = lobbyName;

            dictPlayers.Add(gameOwner, owner);
            
            MaxCapacity = 2;
            IsClosed = false;
        }

        //======================================================
        // Events
        //======================================================
        
        public event GameStartHandler GameStart;
        public event MapChangeHandler MapChange;
        public event PlayerJoinHandler PlayerJoin;
        public event PlayerQuitHandler PlayerQuit;

        private void OnGameStart()
        {
            if (GameStart != null) GameStart();
        }

        private void OnMapChange(IReadOnlyMap map)
        {
            if (MapChange != null) MapChange(map);
        }

        private void OnPlayerJoin(IReadOnlyPlayer player)
        {
            if (PlayerJoin != null) PlayerJoin(player);
        }

        private void OnPlayerQuit(IReadOnlyPlayer player)
        {
            if (PlayerQuit != null) PlayerQuit(player);
        }

        //======================================================
        // Override
        //======================================================

        // Class: IReadOnlyLobby
        public IReadOnlyMap CurrentMap { get { return currentMap; } set { currentMap = value; } }
        public IReadOnlyPlayer Owner { get { return owner; } }
        public int MaxCapacity { get; set; }
        public bool IsClosed { get; set; }   
        
        public IReadOnlyList<IReadOnlyPlayer> ReadOnlylistPlayer
        {
            get
            {
                return (IReadOnlyList<IReadOnlyPlayer>)dictPlayers; 
            }
        }

        // Class: ILobby
        public bool IsPlayerReady(IReadOnlyPlayer player)
        {
            return dictPlayers[player].playerReady;
        }

        public void Join(IReadOnlyPlayer player)
        {
            dictPlayers.Add(player, new GamePlayer(player));
            OnPlayerJoin(player);
        }

        public void KickUser(IReadOnlyPlayer player)
        {
            dictPlayers.Remove(player);
            OnPlayerQuit(player);
        }

        public void Leave(IReadOnlyPlayer player)
        {
            dictPlayers.Remove(player);
            OnPlayerQuit(player);
        }

        public void SetPlayerColor(IPlayer player, Color c)
        {
            dictPlayers[player].Color = c;
        }

        public void SetPlayerReady(IReadOnlyPlayer player, bool ready)
        {
            dictPlayers[player].playerReady = ready;
        }

        public void SetPlayerSpawn(IReadOnlyPlayer player, IReadOnlyNode node)
        {
            if(currentMap.SpawnNodes.Contains(node))
                dictPlayers[player].SpawnNode = node;
            else
                throw new ArgumentException("Spawn attribution is not correct");
        }

        public void StartGame()
        {
            foreach(KeyValuePair<IReadOnlyPlayer, GamePlayer> player in dictPlayers)
            {
                if(!player.Value.playerReady)
                    throw new ApplicationException("Player" + player.Key.PublicPseudo + " is not ready");
                if (player.Value.SpawnNode == null)
                    throw new ApplicationException("Player" + player.Key.PublicPseudo + " has no spawn node");
            }

            if (currentMap == null)
                throw new ApplicationException("No map selected");
            OnGameStart();
        }

        public IDictionary<IReadOnlyNode, IReadOnlyPlayer> spawnAttribution()
        {
            return dictPlayers.ToDictionary( 
                p=> p.Value.SpawnNode,
                p => p.Key);
        }


        //======================================================
        // Internal
        //======================================================

        private class GamePlayer : Player
        {
            public IReadOnlyNode SpawnNode { get; set; }
            public bool playerReady { get; set; }

            public GamePlayer(IReadOnlyPlayer player) : base(player) { }
        }
    }
}