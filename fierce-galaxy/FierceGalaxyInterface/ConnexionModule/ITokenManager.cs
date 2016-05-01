namespace FierceGalaxyInterface
{
    /// <summary>
    /// Manage the connection token of players
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        /// Create a new random connexion token
        /// </summary>
        /// <param name="player">The owner of the token</param>
        /// <returns>The token as a long</returns>
        long GenerateToken(IReadOnlyPlayer player);

        /// <summary>
        /// Remove the player's token, if exist
        /// </summary>
        /// <param name="player">The owner of the token</param>
        void RemoveToken(IReadOnlyPlayer player);

        /// <summary>
        /// Check if the token is still valid
        /// 
        /// If the given token is valide (link to a player and in time range),
        /// the method return true.
        /// Otherwise, if the given token is wrong, the method return false.
        /// </summary>
        /// <param name="token">The token as a long</param>
        /// <returns>True if the token is valid, false otherwise</returns>
        bool IsValid(long token);

        /// <summary>
        /// Get the player associate to this token, if the token is still valid
        /// 
        /// If the given token is valide (link to a player and in time range),
        /// the method return the player.
        /// Otherwise, if the given token is wrong, the method return null.
        /// </summary>
        /// <param name="token">The token as a long</param>
        /// <returns>The player if the token is valid, null otherwise</returns>
        IReadOnlyPlayer GetPlayer(long token);

        /// <summary>
        /// Invalidate the given token
        /// </summary>
        void InvalidateToken(long token);
    }
}
