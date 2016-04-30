using System;
using FierceGalaxyInterface;

namespace FierceGalaxyServer
{
    public class TimestampManager
    {
        //======================================================
        // Field
        //======================================================

        private INetworkTime ntp;
        private DateTime memoryLocalNow;
        private DateTime memoryNetworkNow;

        //======================================================
        // Constructor
        //======================================================

        public TimestampManager(INetworkTime ntp)
        {
            this.ntp = ntp;
            Update();
        }

        //======================================================
        // Access
        //======================================================

        public void Update()
        {
            memoryLocalNow = DateTime.Now;
            memoryNetworkNow = ntp.GetNetworkTime();
        }

        public DateTime GetNetworkTimeStamp()
        {
            return DateTime.Now + GetDifferenceTime();
        }

        public TimeSpan GetDifferenceTime()
        {
            return memoryLocalNow - memoryNetworkNow;
        }
    }
}