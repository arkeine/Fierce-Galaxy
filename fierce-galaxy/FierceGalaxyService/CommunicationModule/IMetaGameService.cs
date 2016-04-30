using System.ServiceModel;
using System.ServiceModel.Web;

namespace FierceGalaxyServer
{
    [ServiceContract]
    public interface IMetaGameService
    {
        /// <summary>
        /// Create the player in database if conditions are met
        /// </summary>
        [OperationContract(IsInitiating = true)]
        [WebInvoke(Method = "POST", 
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "create/player/")]
        void NewPlayer(string playerID, string playerPW, string publicPseudo);

        /// <summary>
        /// Create the player's session if the credentials are correct
        /// </summary>
        [OperationContract(IsInitiating = true)]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "connect/")]
        void Connect(string playerID, string playerPW);

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
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "disconnect/")]
        void Disconnect();
    }
}
