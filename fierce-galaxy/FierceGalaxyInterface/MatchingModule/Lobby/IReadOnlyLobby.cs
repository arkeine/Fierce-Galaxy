using System;
using System.Collections.Generic;

namespace FierceGalaxyInterface
{
    public interface IReadOnlyLobby
    {
        event EventHandler OnPlayerJoin;
        event EventHandler OnPlayerQuit;
        event EventHandler OnMapChange;
        event EventHandler OnGameStart;

        bool IsPlayerReady(IReadOnlyPlayer player);
        IReadOnlyList<IReadOnlyPlayer> PlayerList { get; }
        IReadOnlyMap CurrentMap { get; }
        int PlayerCount { get; }
        int MaxCapacity { get; }
        bool IsClosed { get; }
        IReadOnlyPlayer Owner { get; }
    }
}
