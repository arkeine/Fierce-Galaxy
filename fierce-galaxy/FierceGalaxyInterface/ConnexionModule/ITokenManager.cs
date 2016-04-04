namespace FierceGalaxyInterface.ConnexionModule
{
    public interface ITokenManager
    {
        /// <summary>
        /// Create a new random connexion token
        /// </summary>
        /// <param name="player">The owner of the token</param>
        /// <returns>The token as a long</returns>
        long GenerateToken(IPlayer player);

        /// <summary>
        /// Remove the player's token, if exist
        /// </summary>
        /// <param name="player">The owner of the token</param>
        void RemoveToken(IPlayer player);

        /// <summary>
        /// Use the token for a single connexion. 
        /// 
        /// If the given token is valide (link to a player and in time range),
        /// the method return true and the token is removed.
        /// Otherwise, if the given token is wrong, the method return false.
        /// </summary>
        /// <param name="token">The token as a long</param>
        /// <returns>True if the token is valid, false otherwise</returns>
        bool ConsumeToken(long token);
    }
}
