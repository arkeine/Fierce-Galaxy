using FierceGalaxyInterface;
using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class GameTest
    {
        //======================================================
        // Global tool
        //======================================================

        private static Player p1, p2, p3, p4;
        private static Node n1, n2, n3, n4, n5, n6;
        private static Map testMap;
        private static Game testGame;
        private static IDictionary<IReadOnlyNode, IReadOnlyPlayer> spawnAttribution;

        //Global memory for the listeners
        private bool isGameFinishedCalled;
        private bool isNodeUpdateCalled;
        private bool isSquadLeavesCalled;
        private bool isManaupdateCalled;

        //======================================================
        // Test initialization
        //======================================================

        [ClassInitialize]
        public static void GenerateGlobalContext(TestContext context)
        {
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

            // Map links:
            //
            //   n1          n5
            //      \       /
            //       n3 - n4
            //      /       \
            //   n2          n6

            testMap.AddLink(n1, n3);
            testMap.AddLink(n2, n3);
            testMap.AddLink(n3, n4);
            testMap.AddLink(n4, n5);
            testMap.AddLink(n4, n6);


            // initialise players and a lobby
            p1 = new Player();
            p2 = new Player();
            p3 = new Player();
            p4 = new Player();

            spawnAttribution = new Dictionary<IReadOnlyNode, IReadOnlyPlayer>();
            spawnAttribution[n1] = p1;
            spawnAttribution[n2] = p2;
            spawnAttribution[n5] = p3;
        }

        [TestInitialize]
        public void GenerateLocalContext()
        {
            isNodeUpdateCalled = false;
            isSquadLeavesCalled = false;
            isManaupdateCalled = false;
            isGameFinishedCalled = false;

            testGame = new Game(testMap, spawnAttribution);
            testGame.GameFinished += OnGameFinish;
            testGame.NodeUpdated += OnNodeUpdate;
            testGame.SquadLeaves += OnSquadLeaves;
            testGame.ManaUpdated += OnManaUpdate;
        }

        //======================================================
        // Test case
        //======================================================

        [TestMethod]
        public void FailNodesNotLinked()
        {
            testGame.Move(p1, n1, n2, 10);

            Assert.IsFalse(isSquadLeavesCalled);
            Assert.IsFalse(isNodeUpdateCalled);
        }

        [TestMethod]
        public void SuccessMove()
        {
            testGame.Move(p1, n1, n3, 5);

            Assert.IsTrue(isSquadLeavesCalled);
            Assert.IsTrue(isNodeUpdateCalled);
        }

        //======================================================
        // Listeners
        //======================================================

        private void OnNodeUpdate(IReadOnlyNode node, IReadOnlyPlayer owner, double ressourcesOffset)
        {
            isNodeUpdateCalled = true;
        }

        private void OnSquadLeaves(IReadOnlyNode sourceNode, IReadOnlyNode targetNode, IReadOnlyPlayer owner, double ressources)
        {
            isSquadLeavesCalled = true;
        }

        private void OnManaUpdate(IReadOnlyPlayer player, double currentAmount)
        {
            isManaupdateCalled = true;
        }

        private void OnGameFinish()
        {
            isGameFinishedCalled = true;
        }
    }
}
