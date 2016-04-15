using System.Collections.Generic;

namespace FierceGalaxyInterface
{
    /// <summary>
    /// Manage a corespondance between 
    /// </summary>
    public interface ILobbyManager
    {
        /// <summary>
        /// Allow a player to create a loby
        /// Only on loby per player is allowed
        /// <param name="player">The player who create the server</param>
        /// </summary>
        ILobby CreateLobby(IReadOnlyPlayer player);

        /// <summary>
        /// Allow a player to create a loby
        /// Only the player owner is allowed to delete is lobby
        /// </summary>
        /// <param name="player">The player who want delete the lobby</param>
        void DeleteLobby(IReadOnlyPlayer player);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<ILobby> GetLobbyList();    
    }
}
