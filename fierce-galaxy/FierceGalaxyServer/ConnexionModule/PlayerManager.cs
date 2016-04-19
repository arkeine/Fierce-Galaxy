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
            this.dBPlayerManager = dBManager;
        }

        //======================================================
        // Override
        //======================================================

        public IReadOnlyPlayer CreatePlayer(string pseudo, string playerPW, string publicPseudo)
        {
            CreatePlayerInDatabase(pseudo, playerPW, publicPseudo);
            return Login(pseudo, playerPW);
        }

        public IReadOnlyPlayer Login(string pseudo, string playerPW)
        {
            if (dBPlayerManager.ContainsPlayer(pseudo))
            {
                var dbPlayer = dBPlayerManager.GetPlayer(pseudo);

                if (dbPlayer.playerPW == playerPW)
                {
                    return CreatePlayerFromDBPlayer(dbPlayer);
                }
                else
                {
                    throw new System.ArgumentException("Password for pseudo '" + pseudo + "' is incorrect", "playerPW");
                }                    
            }
            else
            {
                throw new System.ArgumentException("Pseudo '" + pseudo + "' does not exist", "pseudo");
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