using FierceGalaxyInterface;
using System;
using System.Collections.Generic;

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
        
        public event EventHandler OnGameStart;
        public event EventHandler OnMapChange;
        public event EventHandler OnPlayerJoin;
        public event EventHandler OnPlayerQuit;

        // ILobby
        public bool IsPlayerReady(IReadOnlyPlayer player)
        {
            throw new NotImplementedException();
        }

        public void Join(IReadOnlyPlayer player)
        {
            listPlayers.Add(player);
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