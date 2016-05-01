using System;

namespace FierceGalaxyInterface
{
    /// <summary>
    /// This class manage the netwok time stamping and the conversion
    /// between netowrk time stamp to local time stamp
    /// </summary>
    public interface ITimestampManager
    {
        DateTime GetNetworkTimeStamp();

        DateTime NetworkTimeStampToLocalTimeStamp(DateTime t);

        DateTime LocalTimeStampToNetworkTimeStamp(DateTime t);
    }
}
