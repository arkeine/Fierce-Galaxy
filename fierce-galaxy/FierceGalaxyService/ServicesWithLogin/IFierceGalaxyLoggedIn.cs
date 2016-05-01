using System.ServiceModel;
using System.ServiceModel.Web;

namespace FierceGalaxyService.ServicesWithLogin
{
    /*[ServiceContract(
        SessionMode = SessionMode.Required)]*/
    [ServiceContract]
    public interface IFierceGalaxyLoggedIn
    {
        /// <summary>
        /// Create the player's session if the credentials are correct
        /// </summary>
        [OperationContract]
        //[OperationContract(IsInitiating = true)]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "connect/")]
        void Connect();

        /// <summary>
        /// Generate a temporary authentification token for the game side
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "token/")]
        string GenerateConnexionToken();

        /// <summary>
        /// Disconnect the player and close the session
        /// </summary>
        [OperationContract]
        //[OperationContract(IsTerminating = true)]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "disconnect/")]
        void Disconnect();
    }
}
