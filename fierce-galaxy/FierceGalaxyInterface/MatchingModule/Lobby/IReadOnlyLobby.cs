using System;
using System.Collections.Generic;

namespace FierceGalaxyInterface
{
    public delegate void GameStartHandler();
    public delegate void MapChangeHandler(IReadOnlyMap newMap);
    public delegate void PlayerJoinHandler(IReadOnlyPlayer newPlayer);
    public delegate void PlayerQuitHandler(IReadOnlyPlayer quitPlayer);

    public interface IReadOnlyLobby
    {
        event GameStartHandler GameStart;
        event MapChangeHandler MapChange;
        event PlayerJoinHandler PlayerJoin;
        event PlayerQuitHandler PlayerQuit;

        IReadOnlyList<IReadOnlyPlayer> ReadOnlylistPlayer { get; }
        IReadOnlyMap CurrentMap { get; }
        IReadOnlyPlayer Owner { get; }
        int MaxCapacity { get; }
        bool IsClosed { get; }
        bool IsPlayerReady(IReadOnlyPlayer player);
    }
}
