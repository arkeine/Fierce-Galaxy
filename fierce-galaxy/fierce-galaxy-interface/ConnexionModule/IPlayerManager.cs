using FierceGalaxyInterface.GameModule;

namespace FierceGalaxyInterface.ConnexionModule
{
    /// <summary>
    /// Manage the authentification of players
    /// </summary>
    public interface IPlayerManagement
    {
        /// <summary>
        /// Authenticate the player
        /// </summary>
        /// <param name="playerID">Player's acount name</param>
        /// <param name="playerPW">Player's password</param>
        /// <returns>
        /// Return the player or null if the credentials are not valid
        /// </returns>
        IPlayer Login(string playerID, string playerPW);

        /// <summary>
        /// Create a new player acount, but dont login him
        /// </summary>
        /// <param name="playerID">User's acount name</param>
        /// <param name="playerPW">User's password</param>
        /// <param name="publicPseudo">The name the others will see</param>
        /// <returns>
        /// Return the new player or null if the creation fail
        /// </returns>
        IPlayer CreatePlayer(string playerID, string playerPW, string publicPseudo);
    }
}
