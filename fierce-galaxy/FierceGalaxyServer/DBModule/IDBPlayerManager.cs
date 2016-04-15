namespace FierceGalaxyServer
{
    /// <summary>
    /// Minimal interface that DB must implement in orde rto manage players
    /// </summary>
    public interface IDBPlayerManager
    {
        DBPlayer GetPlayer(string key);

        bool ContainsPlayer(string key);

        void SetPlayer(string key, DBPlayer player);
    }
}
