using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class MapManagerTest
    {
        //======================================================
        // Global tool
        //======================================================

        private Node n1, n2, n3;
        private List<Node> listNode;
        private Map map1, map2, map3, map4;
        static private MapManager mapManager;

        //======================================================
        // Test initialization
        //======================================================

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            string directory = Properties.Settings.Default.MapsDBPathTest;
            mapManager = new MapManager(directory);
        }

        [TestInitialize]
        public void Init()
        {
            n1 = new Node();
            n2 = new Node();
            n3 = new Node();

            listNode = new List<Node>(new Node[] { n1, n2, n3 });
            
            map1 = new Map();
            map2 = new Map();
            map3 = new Map();
            map4 = new Map();

            map1.AddNode(n1);
            map1.AddNode(n2);
            map1.AddNode(n3);

            string directory = Properties.Settings.Default.MapsDBPathTest;
            if (Directory.Exists(directory))
            {
                foreach(var f in Directory.GetFiles(directory))
                {
                    File.Delete(f);
                }
                Directory.Delete(directory);
            }
        }

        //======================================================
        // Test case
        //======================================================

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Parameter 'Name' cannot be null")]
        public void SaveMapWithoutNameFail()
        {
            mapManager.SaveMap(map1);
        }
        
        [TestMethod]
        public void SaveMapSuccess()
        {
            map1.Name = "testname1";
            mapManager.SaveMap(map1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Map name already exist")]
        public void SaveMapNameAlreadyExistFail()
        {
            map1.Name = "testDoubleMapName";
            map2.Name = "testDoubleMapName";
            mapManager.SaveMap(map1);
            mapManager.SaveMap(map2);
        }
    }
}
