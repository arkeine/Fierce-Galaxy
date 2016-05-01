using System;
using FierceGalaxyInterface;
using System.Timers;

namespace FierceGalaxyServer
{
    /// <summary>
    /// This class manage the global time stamping relative to local time
    /// 
    /// The purpose is to avoid to send NTP request for every timestamp
    /// </summary>
    public class TimestampManager : ITimestampManager
    {
        //======================================================
        // Field
        //======================================================

        private INetworkTime ntp;
        private DateTime memoryLocalNow;
        private DateTime memoryNetworkNow;
        private Timer timer;

        //======================================================
        // Constructor
        //======================================================

        public TimestampManager(INetworkTime ntp)
        {
            this.ntp = ntp;
            Update();

            //TODO: find if some lock is needed
            timer = new Timer();
            timer.Interval = 60000;
            timer.AutoReset = true;
            timer.Elapsed += OnTimerEvent; 
            timer.Start();
        }

        //======================================================
        // Override
        //======================================================

        public DateTime GetNetworkTimeStamp()
        {
            return DateTime.Now + GetDifferenceTime();
        }

        public DateTime NetworkTimeStampToLocalTimeStamp(DateTime t)
        {
            return t - GetDifferenceTime();
        }

        public DateTime LocalTimeStampToNetworkTimeStamp(DateTime t)
        {
            return t + GetDifferenceTime();
        }

        //======================================================
        // Access
        //======================================================

        public void Update()
        {
            memoryLocalNow = DateTime.Now;
            memoryNetworkNow = ntp.GetNetworkTime();
        }

        //======================================================
        // Private
        //======================================================

        private TimeSpan GetDifferenceTime()
        {
            return memoryLocalNow - memoryNetworkNow;
        }

        private void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            Update();
        }
    }
}