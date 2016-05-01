using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;
using System;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class LobbyTest
    {
        private static Player p1, p2, p3, p4;
        private static Lobby testLobby;
        private static Node n1, n2, n3, n4;
        private static Map testMap;

        [ClassInitialize]
        public static void GenerateGlobalContext(TestContext context)
        {
            // initialise players and a lobby
            p1 = new Player();
            p2 = new Player();
            p3 = new Player();
            p4 = new Player();
            testLobby = new Lobby();
            testLobby.Join(p1);
            testLobby.Join(p2);
            testLobby.Join(p3);

            // initialise a map
            n1 = new Node();
            n2 = new Node();
            n3 = new Node();
            n4 = new Node();
            testMap = new Map();
            testMap.AddNode(n1);
            testMap.AddNode(n2);
            testMap.AddNode(n3);
            testMap.AddNode(n4);
        }

        /// <summary>
        /// A player is not ready
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "Player p3 is not ready")]
        public void CantStartGame_1()
        {
            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);

            testLobby.StartGame();
        }

        /// <summary>
        /// A player has no spawnNode
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "Player p1 has no spawn node")]
        public void CantStartGame_2()
        {
            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.StartGame();
        }

        /// <summary>
        /// A player has no spawnNode
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "No map selected")]
        public void CantStartGame_3()
        {
            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerSpawn(p1, n1);
            testLobby.SetPlayerSpawn(p2, n2);
            testLobby.SetPlayerSpawn(p3, n3);
            testLobby.StartGame();
        }

        /// <summary>
        /// Two players have same spawnNode
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "Two or more players have the same spawn node")]
        public void CantStartGame_4()
        {
            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p2, true);

            testLobby.SetPlayerSpawn(p1, n1);
            testLobby.SetPlayerSpawn(p2, n2);
            testLobby.SetPlayerSpawn(p3, n2);

            testLobby.CurrentMap = testMap;

            testLobby.StartGame();
        }

        /// <summary>
        /// A player has no spawnNode
        /// </summary>
        [TestMethod]
        public void StartGameSuccess()
        {
            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p3, true);

            testLobby.SetPlayerSpawn(p1, n1);
            testLobby.SetPlayerSpawn(p2, n2);
            testLobby.SetPlayerSpawn(p3, n3);

            testLobby.CurrentMap = testMap;

            testLobby.StartGame();
        }

    }
}
