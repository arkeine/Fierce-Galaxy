using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class MapTest 
    {
        private Node n1, n2, n3, n4;
        private Map testMap;

        [TestInitialize]
        public void Init()
        {
            n1 = new Node();
            n2 = new Node();
            n3 = new Node();
            n4 = new Node();
            testMap = new Map();
            testMap.AddNode(n1);
            testMap.AddNode(n2);
            testMap.AddNode(n3);
        }

        [TestMethod]
        public void ControlLink_1()
        {
            testMap.AddLink(n1, n2);
            
            Assert.IsTrue(testMap.AreNodesLinked(n1, n2));
            Assert.IsTrue(testMap.AreNodesLinked(n2, n1));

            testMap.RemoveLink(n1, n2);

            Assert.IsFalse(testMap.AreNodesLinked(n1, n2));
            Assert.IsFalse(testMap.AreNodesLinked(n2, n1));
            Assert.IsFalse(testMap.AreNodesLinked(n4, n1));
            Assert.IsFalse(testMap.AreNodesLinked(n1, n4));
        }

        [TestMethod]
        public void ControlLink_2()
        {
            testMap.AddLink(n1, n2);

            Assert.IsFalse(testMap.AreNodesLinked(n1, n3));
            Assert.IsFalse(testMap.AreNodesLinked(n3, n1));

            testMap.AddLink(n1, n3);

            Assert.IsTrue(testMap.AreNodesLinked(n1, n3));
            Assert.IsTrue(testMap.AreNodesLinked(n3, n1));
        }

        [TestMethod]
        public void CantAddLinkWhenNodeNotAddedToMap()
        {
            int nbNodesBefore = testMap.Nodes.Count;
            
            testMap.AddLink(n1, n2);
            testMap.AddLink(n1, n3);
            testMap.AddLink(n1, n4);
            
            Assert.IsFalse(testMap.AreNodesLinked(n1, n4));
            Assert.IsFalse(testMap.AreNodesLinked(n4, n1));
        }

        [TestMethod]
        public void ControlRemoveNode()
        {
            testMap.AddLink(n1, n2);
            testMap.AddLink(n1, n3);
            testMap.AddLink(n2, n3);

            testMap.RemoveNode(n1);

            Assert.IsTrue(testMap.AreNodesLinked(n2, n3));
            Assert.IsTrue(testMap.AreNodesLinked(n3, n2));

            Assert.IsFalse(testMap.AreNodesLinked(n1, n3));
            Assert.IsFalse(testMap.AreNodesLinked(n3, n1));
        }

        [TestMethod]
        public void CantRemoveUnaddedNode()
        {
            int nbNodesBefore = testMap.Nodes.Count;
            testMap.RemoveNode(n4);
            int nbNodesAfter = testMap.Nodes.Count;

            Assert.IsTrue(nbNodesAfter == nbNodesBefore);
        }
    }
}
