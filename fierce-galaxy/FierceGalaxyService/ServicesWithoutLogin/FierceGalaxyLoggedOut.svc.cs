using System;

namespace FierceGalaxyService.ServicesWithoutLogin
{
    /// <summary>
    /// This service is accessible without connection or loggin
    /// </summary>
    public class FierceGalaxyLoggedOut : IFierceGalaxyLoggedOut
    {
        public void NewPlayer(string userName, string password, string pseudo)
        {
            //TODO: Create the player
            //TODO: Secure agains spam
            throw new NotImplementedException();
        }
    }
}
