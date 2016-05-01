using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static Node n1, n2, n3, n4, n5;
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
            testMap = new Map();
            testMap.AddNode(n1);
            testMap.AddNode(n2);
            testMap.AddNode(n3);
            testMap.AddNode(n4);
            testMap.AddNode(n5);

            testLobby.CurrentMap = testMap;

            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p3, true);

            testLobby.SetPlayerSpawn(p1, n1);
            testLobby.SetPlayerSpawn(p2, n2);
            testLobby.SetPlayerSpawn(p3, n3);

            testLobby.StartGame();

            testGame = new Game(testLobby.CurrentMap, testLobby.spawnAttribution());

        }
    }
}
