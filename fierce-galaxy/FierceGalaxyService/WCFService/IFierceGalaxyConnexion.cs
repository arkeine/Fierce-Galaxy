using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace FierceGalaxyService
{
    [ServiceContract]
    public interface IFierceGalaxyConnexionService
    {
        /// <summary>
        /// Create the player in database if conditions are met
        /// </summary>
        [OperationContract(IsInitiating = true)]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "create/player/")]
        string NewPlayer(string userName, string password, string pseudo);

        /// <summary>
        /// Create the player's session if the credentials are correct
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "connect/")]
        string Connect(string userName, string password);

        /// <summary>
        /// Disconnect the player and close the session
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "disconnect/")]
        string Disconnect(string token);
    }
}
