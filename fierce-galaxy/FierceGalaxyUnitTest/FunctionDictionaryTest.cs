using FierceGalaxyInterface;
using FierceGalaxyServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class FunctionDictionaryTest
    {
        private Node n;
        private FunctionDictionary<IReadOnlyNode> nm;

        [TestInitialize]
        public void CreateLocalContext()
        {
            n = new Node();
            nm = new FunctionDictionary<IReadOnlyNode>(
                    delegate (double t) { return t; }
                );
        }

        [TestMethod]
        public void UseWithChangeTimeOffset()
        {
            //At time 0
            CheckNodeValue(0);

            //At time 30s
            nm.Zero = (DateTime.Now - TimeSpan.FromSeconds(30));
            CheckNodeValue(30);

            //At time 30s with 10 ressources offset
            nm.SetCurrentValue(n, 10);
            CheckNodeValue(10);

            //At time 30s with 20 ressources offset
            nm.SetCurrentValue(n, 20);
            CheckNodeValue(20);

            //At time 45s with previous offset of 20
            nm.Zero = (DateTime.Now - TimeSpan.FromSeconds(45));
            CheckNodeValue(35);
        }

        [TestMethod]
        public void UseWithSleep()
        {
            //At time 0
            Assert.AreEqual(0, nm.GetCurrentValue(n));

            //At time 3s
            System.Threading.Thread.Sleep(3000);
            CheckNodeValue(3);

            //At time 6s 
            System.Threading.Thread.Sleep(3000);
            CheckNodeValue(6);

            //At time 10s with reset
            nm.SetCurrentValue(n, 0);
            System.Threading.Thread.Sleep(4000);
            CheckNodeValue(4);
        }

        [TestMethod]
        public void UseWithInitialOffset()
        {
            //At time 0
            Assert.AreEqual(0, nm.GetCurrentValue(n));
            nm.SetCurrentValue(n, 10);
            CheckNodeValue(10);

            //At time 3s
            System.Threading.Thread.Sleep(3000);
            CheckNodeValue(13);
        }

        private void CheckNodeValue(double expected)
        {
            Assert.IsTrue(Tools.AreDoubleEqual(expected, nm.GetCurrentValue(n), 0.1));
        }
    }
}
