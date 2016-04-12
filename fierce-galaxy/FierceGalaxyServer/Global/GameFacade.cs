using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public class GameFacade : IGameFacade
    {
        //======================================================
        // Field
        //======================================================

        private IPlayerManager playerManager;

        //======================================================
        // Singleton
        //======================================================

        private static GameFacade singleton;

        public static GameFacade GetInstance()
        {
            if (singleton == null)
            {
                singleton = new GameFacade();
            }

            return singleton;
        }

        private GameFacade()
        {
            playerManager = new PlayerManager();
        }

        //======================================================
        // Override
        //======================================================

        public IPlayerManager PlayerManager
        {
            get
            {
                return playerManager;
            }
        }
    }
}