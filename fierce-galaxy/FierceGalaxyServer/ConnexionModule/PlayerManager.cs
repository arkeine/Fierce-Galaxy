using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    /// <summary>
    /// Singleton class
    /// Access the database to check player credentials
    /// </summary>
    public class PlayerManager : IPlayerManager
    {
        //======================================================
        // Field
        //======================================================
        
        private IDBPlayerManager dBPlayerManager;

        //======================================================
        // Constructor
        //======================================================

        public PlayerManager(IDBPlayerManager dBManager)
        {
            dBPlayerManager = dBManager;
        }

        //======================================================
        // Override
        //======================================================

        public IReadOnlyPlayer CreatePlayer(string userName, string password, string pseudo)
        {
            CreatePlayerInDatabase(userName, password, pseudo);
            return Login(userName, password);
        }

        public IReadOnlyPlayer Login(string userName, string password)
        {
            if (dBPlayerManager.ContainsPlayer(userName))
            {
                var dbPlayer = dBPlayerManager.GetPlayer(userName);

                if (dbPlayer.playerPW == password)
                {
                    return CreatePlayerFromDBPlayer(dbPlayer);
                }
                else
                {
                    throw new System.ArgumentException("Password for pseudo '" + userName + "' is incorrect", "playerPW");
                }                    
            }
            else
            {
                throw new System.ArgumentException("Pseudo '" + userName + "' does not exist", "pseudo");
            }
        }

        //======================================================
        // Private
        //======================================================
        
        private IPlayer CreatePlayerFromDBPlayer(DBPlayer dbPlayer)
        {
            var player = new Player();
            player.PublicPseudo = dbPlayer.publicPseudo;
            return player;
        }

        private void CreatePlayerInDatabase(string pseudo, string playerPW, string publicPseudo)
        {
            if(!dBPlayerManager.ContainsPlayer(pseudo))
            {
                DBPlayer newPlayer = new DBPlayer(pseudo, playerPW, publicPseudo);
                dBPlayerManager.SetPlayer(pseudo, newPlayer);
            }
            else
            {
                throw new System.ArgumentException("Pseudo '" + pseudo + "' is already used", "pseudo");
            }
        }
    }
}