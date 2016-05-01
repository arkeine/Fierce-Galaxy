using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FierceGalaxyServer
{
    public class Lobby : ILobby
    {
        //======================================================
        // Field
        //======================================================

        private IList<IReadOnlyPlayer> listPlayers;
        private IReadOnlyMap currentMap;
        private IReadOnlyPlayer owner;

        //======================================================
        // Constructor
        //======================================================

        public Lobby()
        {
            listPlayers = new List<IReadOnlyPlayer>();
            currentMap = new Map();
            owner = new Player();
        }

        public Lobby(string name, IReadOnlyPlayer gameOwner)
        {
            owner = gameOwner;
            listPlayers = new List<IReadOnlyPlayer>();
            listPlayers.Add(owner);
            currentMap = null;
            
            PlayerCount = 1;
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

        // IReadOnlyLobby
        public IReadOnlyMap CurrentMap { get { return currentMap; } }
        public IReadOnlyPlayer Owner { get { return owner; } }
        public int PlayerCount { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsClosed { get; set; }   
        
        public IReadOnlyList<IReadOnlyPlayer> ReadOnlylistPlayer
        {
            get
            {
                return (IReadOnlyList<IReadOnlyPlayer>)listPlayers; 
            }
        }

        // ILobby
        public bool IsPlayerReady(IReadOnlyPlayer player)
        {
            throw new NotImplementedException();
        }

        public void Join(IReadOnlyPlayer player)
        {
            if(!listPlayers.Contains(player))
            {
                listPlayers.Add(player);
            }
                
        }

        public void KickUser(IReadOnlyPlayer player)
        {
            throw new NotImplementedException();
        }

        public void Leave(IReadOnlyPlayer player)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerColor(IPlayer player, Color c)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerReady(IReadOnlyPlayer player, bool ready)
        {
            throw new NotImplementedException();
        }

        public void SetSpawn(IReadOnlyPlayer player, IReadOnlyNode node)
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}