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
            TimeSpan epsilon = new TimeSpan(0, 0, 0, 0, 200);

            var networkTime= new NetworkTime().GetNetworkTime();
            var systemTime = DateTime.Now;
            var diffTime = networkTime - systemTime;
            
            Assert.IsTrue(diffTime.CompareTo(epsilon) <= 0);
        }
    }
}
