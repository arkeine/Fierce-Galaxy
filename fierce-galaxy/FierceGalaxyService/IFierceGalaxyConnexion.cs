﻿using System.ServiceModel;
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
        string CreatePlayer(string userName, string password, string pseudo);

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
        void Disconnect(string token);

        /// <summary>
        /// Disconnect the player and close the session
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "game/port")]
        string GetGameFacadePort(string token);
    }
}
