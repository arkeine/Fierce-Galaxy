using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FierceGalaxyServer.MatchingModule.ByLobby
{
    public class Lobby //: ILobby
    {
        public IReadOnlyMap CurrentMap
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int MaxPlayers
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<IReadOnlyPlayer> PlayerList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler MapChange;
        public event EventHandler PlayerJoin;
        public event EventHandler PlayerQuit;

        public void Join(IReadOnlyPlayer player)
        {
            throw new NotImplementedException();
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

        public void SetSpawn(IReadOnlyPlayer player, IReadOnlyNode node)
        {
            throw new NotImplementedException();
        }
    }
}