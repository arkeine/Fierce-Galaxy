using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class MapTest
    {
        private Node n1, n2, n3;
        private Map testMap;

        [TestInitialize]
        public void init()
        {
            n1 = new Node();
            n2 = new Node();
            n3 = new Node();
            testMap = new Map();
            testMap.AddNode(n1);
            testMap.AddNode(n2);
            testMap.AddNode(n3);
        }


        [TestMethod]
        public void CreateMap()
        {  
            testMap.AddLink(


            Assert.Fail();
        }
    }
}
