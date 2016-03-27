using FierceGalaxyInterface.ConnexionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FierceGalaxyInterface.GameModule;

namespace FierceGalaxyServer.ConnexionModule
{
    public class PlayerManagement : IPlayerManagement
    {
        public IPlayer CreatePlayer(string playerID, string playerPW, string publicPseudo)
        {
            throw new NotImplementedException();
        }

        public IPlayer Login(string playerID, string playerPW)
        {
            throw new NotImplementedException();
        }
    }
}