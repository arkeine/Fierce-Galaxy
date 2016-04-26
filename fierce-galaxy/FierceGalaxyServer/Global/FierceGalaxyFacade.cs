using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public class GameFacade : IFierceGalaxyFacade
    {
        //======================================================
        // Field
        //======================================================

        private IPlayerManager playerManager;
        //private IMapSerializer mapManager;

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
            playerManager = new PlayerManager(new DBJsonManager());
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