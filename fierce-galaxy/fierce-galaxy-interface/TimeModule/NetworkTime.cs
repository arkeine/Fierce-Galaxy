using System;

namespace FierceGalaxyInterface.TimeModule
{
    public interface NetworkTime
    {
        /// <summary>
        /// Return the time from a default NTP server
        /// </summary>
        DateTime GetNetworkTime();

        /// <summary>
        /// Return the time from the given NTP server
        /// </summary>
        DateTime GetNetworkTime(string serverURL);
    }
}
