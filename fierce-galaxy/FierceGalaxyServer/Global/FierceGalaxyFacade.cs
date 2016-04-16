using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public class GameFacade : IFierceGalaxyFacade
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
            string dbFilePath = Properties.Settings.Default.JsonDBPath;
            playerManager = new PlayerManager(new DBJsonManager(dbFilePath));
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