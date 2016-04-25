using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class NodeManagerTest
    {
        [TestMethod]
        public void UseWithChangeTimeOffset()
        {
            Node n = new Node();
            NodeManager nm = new NodeManager();

            //At time 0
            Assert.AreEqual(0, nm.GetCurrentNodeRessources(n));

            //At time 30s
            nm.Zero = (DateTime.Now - TimeSpan.FromSeconds(30));
            Assert.AreEqual(30, nm.GetCurrentNodeRessources(n));

            //At time 30s with 10 ressources offset
            nm.SetCurrentNodeRessources(n, 10);
            Assert.AreEqual(10, nm.GetCurrentNodeRessources(n));

            //At time 30s with 20 ressources offset
            nm.SetCurrentNodeRessources(n, 20);
            Assert.AreEqual(20, nm.GetCurrentNodeRessources(n));

            //At time 45s with previous offset of 20
            nm.Zero = (DateTime.Now - TimeSpan.FromSeconds(45));
            Assert.AreEqual(35, nm.GetCurrentNodeRessources(n));
        }

        [TestMethod]
        public void UseWithSleep()
        {
            Node n = new Node();
            NodeManager nm = new NodeManager();

            //At time 0
            Assert.AreEqual(0, nm.GetCurrentNodeRessources(n));

            //At time 3s
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual(3, nm.GetCurrentNodeRessources(n));

            //At time 6s 
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual(6, nm.GetCurrentNodeRessources(n));

            //At time 10s with reset
            nm.SetCurrentNodeRessources(n, 0);
            System.Threading.Thread.Sleep(4000);
            Assert.AreEqual(4, nm.GetCurrentNodeRessources(n));
        }
    }
}
