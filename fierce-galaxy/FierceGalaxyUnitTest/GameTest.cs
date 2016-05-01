using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class GameTest
    {
        //======================================================
        // Global tool
        //======================================================

        private static Player p1, p2, p3, p4;
        private static Lobby testLobby;
        private static Node n1, n2, n3, n4, n5, n6;
        private static Map testMap;
        private static Game testGame;


        [ClassInitialize]
        public static void GenerateGlobalContext(TestContext context)
        {
            // initialise players and a lobby
            p1 = new Player();
            p2 = new Player();
            p3 = new Player();
            p4 = new Player();
            testLobby = new Lobby("test lobby", p1);
            testLobby.Join(p2);
            testLobby.Join(p3);

            // initialise a map
            n1 = new Node();
            n2 = new Node();
            n3 = new Node();
            n4 = new Node();
            n5 = new Node();
            n6 = new Node();

            n1.MaxRessource = 10;
            n2.MaxRessource = 20;
            n3.MaxRessource = 30;
            n4.MaxRessource = 40;
            n5.MaxRessource = 50;
            n6.MaxRessource = 60;

            n1.InitialRessource = 5;
            n2.InitialRessource = 5;
            n5.InitialRessource = 5;

            testMap = new Map();
            testMap.AddNode(n1);
            testMap.AddNode(n2);
            testMap.AddNode(n3);
            testMap.AddNode(n4);
            testMap.AddNode(n5);
            testMap.AddNode(n6);
            testMap.SetSpawnNode(n1, true);
            testMap.SetSpawnNode(n2, true);
            testMap.SetSpawnNode(n5, true);

            // n1          n5
            //    \       /
            //     n3 - n4
            //    /       \
            // n2          n6

            testMap.AddLink(n1, n3);
            testMap.AddLink(n2, n3);
            testMap.AddLink(n3, n4);
            testMap.AddLink(n4, n5);
            testMap.AddLink(n4, n6);
            

            testLobby.CurrentMap = testMap;

            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p3, true);

            testLobby.SetPlayerSpawn(p1, n1);
            testLobby.SetPlayerSpawn(p2, n2);
            testLobby.SetPlayerSpawn(p3, n5);

            testLobby.StartGame();

            testGame = new Game(testLobby.CurrentMap, testLobby.spawnAttribution());

        }

        [TestMethod]
        public void FailNodesNotLinked()
        {
            testGame.Move(p1, n1, n2, 10);
        }

        [TestMethod]
        public void FailRessourcesTooLow()
        {
            testGame.Move(p1, n1, n3, 100);
        }

    }
}
