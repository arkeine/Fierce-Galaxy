using FierceGalaxyServer.MapModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    class MapTest
    {
        [TestMethod]
        public void t01_createMap()
        {
            Map testMap = new Map();
            testMap.Description = "Description of testMap";
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = PlayerManager.GetInstance();

            if (playerManager.MapDBPlayers.ContainsKey(pseudo))
                playerManager.MapDBPlayers.Remove(pseudo);

            try
            {
                playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            }
            catch (Exception)
            {
                Console.WriteLine("Pseudo déjà utilisé!");
            }
            Assert.IsTrue(playerManager.MapDBPlayers.ContainsKey(pseudo));
        }
    }
}
