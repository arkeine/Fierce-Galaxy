namespace FierceGalaxyServer
{
    /// <summary>
    /// Minimal interface that DB must implement in orde rto manage maps
    /// </summary>
    public interface IDBMapManager
    {
        DBMap GetMap(string key);

        bool ContainsMap(string key);

        void SetMap(string key, DBMap map);
    }
}