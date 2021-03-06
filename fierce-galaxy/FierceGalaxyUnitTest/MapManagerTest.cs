﻿using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            mapManager = new MapManager();
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
        }

        //======================================================
        // Test case
        //======================================================

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Parameter 'Name' cannot be null")]
        public void SaveMapWithoutNameFail()
        {
            DBMap dbMap1 = new DBMap(map1);
            mapManager.SaveMap(dbMap1);
        }
        
        [TestMethod]
        public void SaveMapSuccess()
        {
            int n = 1;
            DBMap dbMap1 = new DBMap(map1);
            bool exist = true;

            while (exist)
            {
                dbMap1.Name = "testname1 #" + n;
                try
                {
                    mapManager.SaveMap(dbMap1);
                    exist = false;
                }
                catch (ArgumentException e)
                {
                    if (e.Message.Contains("Map name already exist"))
                    {
                        n += 1;
                    }
                    else
                    {
                        throw;
                    }
                }                
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Map name already exist")]
        public void SaveMapNameAlreadyExistFail()
        {
            DBMap dbMap1 = new DBMap(map1);
            dbMap1.Name = "testDoubleMapName";
            DBMap dbMap2 = new DBMap(map2);
            dbMap2.Name = "testDoubleMapName";
            mapManager.SaveMap(dbMap1);
            mapManager.SaveMap(dbMap2);
        }
    }
}
