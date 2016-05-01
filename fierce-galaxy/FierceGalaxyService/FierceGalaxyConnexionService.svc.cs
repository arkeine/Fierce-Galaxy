using System;

namespace FierceGalaxyService
{
    /// <summary>
    /// This service is accessible without connection or loggin
    /// </summary>
    public class FierceGalaxyConnexionService : IFierceGalaxyConnexionService
    {
        public string Connect(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string Disconnect(string token)
        {
            throw new NotImplementedException();
        }

        public string GetGameFacadePort(string token)
        {
            throw new NotImplementedException();
        }

        public string NewPlayer(string userName, string password, string pseudo)
        {
            throw new NotImplementedException();
        }
    }
}
