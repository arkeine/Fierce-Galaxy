using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class NetworkTimeTest
    {
        //======================================================
        // Test case
        //======================================================

        [TestMethod]
        public void CompareNetworkTimeToSystemTime()
        {
            TimeSpan epsilon = new TimeSpan(0, 0, 0, 0, 200);

            var n1 = new NetworkTime();
            var n2 = new NetworkTime();
            var n3 = new NetworkTime();

            n1.ServerURL = "ch.pool.ntp.org";
            n1.ServerURL = "fr.pool.ntp.org";
            n3.ServerURL = "de.pool.ntp.org";

            Assert.IsTrue((n1.GetNetworkTime() - n2.GetNetworkTime()).CompareTo(epsilon) <= 0);
            Assert.IsTrue((n2.GetNetworkTime() - n2.GetNetworkTime()).CompareTo(epsilon) <= 0);
            Assert.IsTrue((n3.GetNetworkTime() - n2.GetNetworkTime()).CompareTo(epsilon) <= 0);
            Assert.IsTrue((n1.GetNetworkTime() - n3.GetNetworkTime()).CompareTo(epsilon) <= 0);
            Assert.IsTrue((n2.GetNetworkTime() - n3.GetNetworkTime()).CompareTo(epsilon) <= 0);
            Assert.IsTrue((n2.GetNetworkTime() - n1.GetNetworkTime()).CompareTo(epsilon) <= 0);
            Assert.IsTrue((n3.GetNetworkTime() - n1.GetNetworkTime()).CompareTo(epsilon) <= 0);
        }
    }
}
