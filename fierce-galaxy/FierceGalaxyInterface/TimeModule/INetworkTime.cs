using System;

namespace FierceGalaxyInterface
{
    public interface INetworkTime
    {
        /// <summary>
        /// Return the time from a NTP server
        /// </summary>
        DateTime GetNetworkTime();
    }
}
