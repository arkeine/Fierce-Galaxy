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

        IReadOnlyList<IReadOnlyPlayer> ReadOnlylistPlayer { get; }
        IReadOnlyMap CurrentMap { get; }
        IReadOnlyPlayer Owner { get; }
        int PlayerCount { get; }
        int MaxCapacity { get; }
        bool IsClosed { get; }
        bool IsPlayerReady(IReadOnlyPlayer player);
    }
}
