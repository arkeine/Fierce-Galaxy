using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;
using System;
using FierceGalaxyInterface;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class LobbyTest
    {
        //======================================================
        // Global tool
        //======================================================

        private static Player p1, p2, p3, p4;
        private static Node n1, n2, n3, n4, n5;
        private static Map testMap;

        private Lobby testLobby;
        private bool isGameStarted;
        private bool isPlayerJoined;
        private bool isPlayerLeaved;
        private bool isMapChanged;

        //======================================================
        // Test initialization
        //======================================================

        [ClassInitialize]
        public static void GenerateGlobalContext(TestContext context)
        {
            // initialise players
            p1 = new Player();
            p2 = new Player();
            p3 = new Player();
            p4 = new Player();

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
            testMap.SetSpawnNode(n1, true);
            testMap.SetSpawnNode(n2, true);
            testMap.SetSpawnNode(n3, true);

        }

        [TestInitialize]
        public void GenerateLocalContext()
        {
            testLobby = new Lobby("test lobby", p1);

            isGameStarted = false;
            isPlayerJoined = false;
            isPlayerLeaved = false;
            isMapChanged = false;

            testLobby.GameStart += OnGameStart;
            testLobby.PlayerJoin += OnPlayerJoin;
            testLobby.PlayerQuit += OnPlayerLeave;
            testLobby.MapChange += OnMapChanged;
        }

        //======================================================
        // Test case
        //======================================================

        /// <summary>
        /// A player is not ready
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "Player p2 is not ready")]
        public void PlayerNotReady()
        {
            testLobby.Join(p2);
            testLobby.Join(p3);

            testLobby.SetPlayerReady(p1, true);

            testLobby.CurrentMap = testMap;

            testLobby.StartGame();
        }

        [TestMethod]
        public void PlayerJoinLeave()
        {
            testLobby.Join(p2);
            Assert.IsTrue(isPlayerJoined);
            testLobby.Leave(p2);
            Assert.IsTrue(isPlayerLeaved);
        }

        [TestMethod]
        public void MapChanged()
        {
            testLobby.CurrentMap = testMap;
            Assert.IsTrue(isMapChanged);
        }

        /// <summary>
        /// A player has no spawnNode
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "Player p1 has no spawn node")]
        public void SpawnAttributionMissing()
        {
            testLobby.Join(p2);
            testLobby.Join(p3);

            testLobby.CurrentMap = testMap;

            testLobby.SetPlayerSpawn(p2, n2);
            testLobby.SetPlayerSpawn(p3, n3);

            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p3, true);

            testLobby.StartGame();
        }
        

        /// <summary>
        /// A player has no spawnNode
        /// </summary>
        [TestMethod]
        public void StartGameSuccess()
        {
            testLobby.Join(p2);
            testLobby.Join(p3);

            testLobby.CurrentMap = testMap;

            testLobby.SetPlayerSpawn(p1, n1);
            testLobby.SetPlayerSpawn(p2, n2);
            testLobby.SetPlayerSpawn(p3, n3);

            testLobby.SetPlayerReady(p1, true);
            testLobby.SetPlayerReady(p2, true);
            testLobby.SetPlayerReady(p3, true);

            testLobby.StartGame();

            Assert.IsTrue(isGameStarted);
        }

        //======================================================
        // Listeners
        //======================================================

        private void OnGameStart()
        {
            isGameStarted = true;
        }

        private void OnPlayerJoin(IReadOnlyPlayer newPlayer)
        {
            isPlayerJoined = true;
        }

        private void OnPlayerLeave(IReadOnlyPlayer quitPlayer)
        {
            isPlayerLeaved = true;
        }

        private void OnMapChanged(IReadOnlyMap newMap)
        {
            isMapChanged = true;
        }
    }
}
