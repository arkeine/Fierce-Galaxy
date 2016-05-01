using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace FierceGalaxyService.ServicesWithoutLogin
{
    [ServiceContract]
    public interface IFierceGalaxyLoggedOut
    {
        /// <summary>
        /// Create the player in database if conditions are met
        /// </summary>
        [OperationContract(IsInitiating = true)]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "create/player/")]
        void NewPlayer(string userName, string password, string pseudo);
    }
}
