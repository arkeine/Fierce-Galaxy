using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class MapTest 
    {
        private Node n1, n2, n3;
        private Map testMap;

        [TestInitialize]
        public void Init()
        {
            n1 = new Node();
            n1 = new Node();
            n1 = new Node();
            testMap = new Map();
            testMap.AddNode(n1);
            testMap.AddNode(n2);
            testMap.AddNode(n3); 
        }

        [TestMethod]
        public void Test1()
        {
            testMap.AddLink(n1, n2);
            
            Assert.IsTrue(testMap.AreNodesLinked(n1, n2));
        }
    }
}
