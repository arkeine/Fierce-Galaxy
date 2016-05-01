using System.ServiceModel;
using System.ServiceModel.Web;

namespace FierceGalaxyService.ServicesWithLogin
{
    [ServiceContract]
    public interface IFierceGalaxyLoggedIn
    {
        /// <summary>
        /// Create the player's session if the credentials are correct
        /// </summary>
        [OperationContract(IsInitiating = true)]
        [WebInvoke(Method = "POST",
            UriTemplate = "connect/")]
        void Connect();

        /// <summary>
        /// Generate a temporary authentification token for the game side
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "connect/")]
        long GenerateConnexionToken();

        /// <summary>
        /// Disconnect the player and close the session
        /// </summary>
        [OperationContract(IsTerminating = true)]
        [WebInvoke(Method = "POST",
            UriTemplate = "disconnect/")]
        void Disconnect();
    }
}
