using FierceGalaxyInterface;
using FierceGalaxyServer;
using System;

namespace FierceGalaxyService
{


    /// <summary>
    /// This service is accessible without connection or loggin
    /// </summary>
    public class FierceGalaxyConnexionService : IFierceGalaxyConnexionService
    {
        //======================================================
        // Field
        //======================================================

        private IPlayerManager playerManager;
        private ITokenManager tokenManager;

        //======================================================
        // Constructor
        //======================================================

        public FierceGalaxyConnexionService()
        {
            playerManager = new PlayerManager(new DBJsonManager());
            tokenManager = new TokenManager();
        }

        //======================================================
        // Override
        //======================================================

        public string Connect(string userName, string password)
        {
            try
            {
                var p = playerManager.Login(userName, password);
                var t = tokenManager.GenerateToken(p);
                return ToJson(t);
            }
            catch(ArgumentException e)
            {
                return ToJson(e);
            }
        }

        public void Disconnect(string token)
        {
            tokenManager.InvalidateToken(Int64.Parse(token));
        }
        
        public string GetGameFacadePort(string token)
        {
            throw new NotImplementedException();
        }

        public string CreatePlayer(string userName, string password, string pseudo)
        {
            try
            {
                var p = playerManager.CreatePlayer(userName, password, pseudo);
                var t = tokenManager.GenerateToken(p);
                return ToJson(t);
            }
            catch (ArgumentException e)
            {
                return ToJson(e);
            }
        }

        //======================================================
        // Private
        //======================================================

        private string ToJson(Object o)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(o);
        }
    }
}
