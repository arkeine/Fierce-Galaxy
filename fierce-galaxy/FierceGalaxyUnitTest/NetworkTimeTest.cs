using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class NetworkTimeTest 
    {
        [TestMethod]
        public void CompareNetworkTimeToSystemTime()
        {
            const double epsilon = 0.2;

            var networkTime= new NetworkTime().GetNetworkTime();
            var systemTime = DateTime.Now;
            var diffTime = networkTime - systemTime;
            
            Assert.IsTrue(diffTime.CompareTo(epsilon) <= 0);
        }
    }
}
