using System;

namespace FierceGalaxyInterface.TimeModule
{
    public interface INetworkTime
    {
        /// <summary>
        /// Return the time from a NTP server
        /// </summary>
        DateTime GetNetworkTime();
    }
}
