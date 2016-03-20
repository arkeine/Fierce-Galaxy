using System;
using System.Net;

namespace FierceGalaxyInterface.Convertion
{
    /// <summary>
    /// The user manager make the corespondance between low-level
    /// socket communication and Object in high level classes
    /// </summary>
    public interface IUserManager
    {
        bool AddUser(String pseudo, IPAddress ip, int port);
        
        /// <summary>
        /// Remove the user from the manager and invalidate it
        /// <returns></returns>
        bool RemoveUser(IUser user);

        IUser GetUser(IPAddress ip, int port);
        IUser GetUser(String pseudo);  
    }
}
