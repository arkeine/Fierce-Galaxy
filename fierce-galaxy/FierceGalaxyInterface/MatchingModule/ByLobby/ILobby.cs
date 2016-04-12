﻿using System;
using System.Collections.Generic;

namespace FierceGalaxyInterface
{
    public interface ILobby
    {
        //======================================================
        // About players
        //======================================================

        event EventHandler PlayerJoin;
        event EventHandler PlayerQuit;

        void Join(IReadOnlyPlayer player);
        void KickUser(IReadOnlyPlayer player);
        void SetPlayerColor(IPlayer player, Color c);

        IReadOnlyList<IReadOnlyPlayer> PlayerList
        {
            get;
        }

        int PlayerCount
        {
            get;
            set;
        }

        int MaxCapacity
        {
            get;
            set;
        }

        //======================================================
        // About map
        //======================================================

        event EventHandler MapChange;

        IReadOnlyMap CurrentMap
        {
            get;
            set;
        }

        void SetSpawn(IReadOnlyPlayer player, IReadOnlyNode node);
    }
}
