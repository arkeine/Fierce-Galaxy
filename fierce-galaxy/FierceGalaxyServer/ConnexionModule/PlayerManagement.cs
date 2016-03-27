using FierceGalaxyInterface.ConnexionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FierceGalaxyInterface.GameModule;
using System.Collections;

namespace FierceGalaxyServer.ConnexionModule
{
    public class PlayerManagement : IPlayerManagement
    {
        private IList listPlayer = new ArrayList();

        public PlayerManagement()
        {

        }


        public IPlayer CreatePlayer(string playerID, string playerPW, string publicPseudo)
        {
            listPlayer.Add
        }

        public IPlayer Login(string playerID, string playerPW)
        {
            listPlayer.
        }
    }
}