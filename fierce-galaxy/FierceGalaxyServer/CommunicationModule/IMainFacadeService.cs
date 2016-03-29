using System.ServiceModel;

namespace FierceGalaxyServer.CommunicationModule
{
    [ServiceContract]
    public interface IMainFacadeService 
    {
        /// <summary>
        /// Create the player's session if the credentials are correct
        /// </summary>
        [OperationContract(IsInitiating = true)]
        void Connect(string playerID, string playerPW);

        /// <summary>
        /// Generate a temporary authentification token for the game side
        /// </summary>
        [OperationContract]
        long GenerateConnexionToken();

        /// <summary>
        /// Disconnect the player and close the session
        /// </summary>
        [OperationContract(IsTerminating = true)]
        void Disconnect();
    }
}
