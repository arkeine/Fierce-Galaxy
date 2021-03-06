﻿namespace FierceGalaxyInterface
{
    /// <summary>
    /// Manage the authentication of players
    /// </summary>
    public interface IPlayerManager
    {
        /// <summary>
        /// Authenticate the player
        /// </summary>
        /// <param name="userName">Player's acount name</param>
        /// <param name="password">Player's password</param>
        /// <returns>
        /// Return the player or null if the credentials are not valid
        /// </returns>
        IReadOnlyPlayer Login(string userName, string password);

        /// <summary>
        /// Create a new player acount, but dont login him
        /// </summary>
        /// <param name="userName">User's acount name</param>
        /// <param name="playerPW">User's password</param>
        /// <param name="pseudo">The name the others will see</param>
        /// <returns>
        /// Return the new player or null if the creation fail
        /// </returns>
        IReadOnlyPlayer CreatePlayer(string userName, string password, string pseudo);
    }
}
