namespace FierceGalaxyInterface
{
    public interface ILobby : IReadOnlyLobby
    {        
        void Join(IReadOnlyPlayer player);
        void KickUser(IReadOnlyPlayer player);
        void SetPlayerSpawn(IReadOnlyPlayer player, IReadOnlyNode node);
        void SetPlayerColor(IPlayer player, Color c);
        void StartGame();
        void SetPlayerReady(IReadOnlyPlayer player, bool ready);
        
    }
}
