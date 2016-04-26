using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class MapManagerTest
    {
        [TestMethod]
        public void CreateMap()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            MapManager mapManager = new MapManager();

            Node node_1 = new Node();
            List<Node> listNodes = new List<Node>();
            listNodes.Add(new Node());
            Map map_1 = new Map("first mapt", "this is my first map");
            DBMap dbMap = new DBMap(map_1);
            mapManager.SaveMap(dbMap);

            /*playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            IPlayer p = playerManager.Login(pseudo, playerPW);
            Assert.AreEqual(playerManager.Login(pseudo, playerPW).PublicPseudo, publicPseudo);*/
        }
    }
}
