using FierceGalaxyInterface.ConnexionModule;
using System.ServiceModel;

namespace FierceGalaxyServer
{
    [ServiceContract]
    public interface IAcountManagementServer : IPlayerManagement
    {
        [OperationContract]
        new long Connect(string userID, string userPW);
        
        [OperationContract]
        new void Disconnect(long token);
    }
}
