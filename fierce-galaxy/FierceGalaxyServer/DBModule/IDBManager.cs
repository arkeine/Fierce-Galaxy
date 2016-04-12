namespace FierceGalaxyServer
{
    public interface IDBManager
    {
        DBPlayer GetPlayer(string key);

        bool ContainsPlayer(string key);

        void SetPlayer(string key, DBPlayer player);
    }
}
