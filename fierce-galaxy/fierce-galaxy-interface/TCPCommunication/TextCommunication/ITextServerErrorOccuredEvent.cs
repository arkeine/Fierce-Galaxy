using System.Net;

namespace FierceGalaxyInterface.Communication
{
    public enum ErrorCode { ConnexionLost };

    /// <summary>
    /// Event emit when the text server rise an error
    /// </summary>
    public interface ITextServerErrorOccuredEvent 
    {
        ErrorCode Error
        {
            get;
        }

        IPAddress IPSource
        {
            get;
        }

        int Port
        {
            get;
        }
    }
}
