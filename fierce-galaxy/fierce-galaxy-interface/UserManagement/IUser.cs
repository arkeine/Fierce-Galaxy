using System;
using System.Net;

namespace FierceGalaxyInterface.Convertion
{
    public interface IUser
    {        
        IPAddress IPAddress
        {
            get;
        }
        
        int Port
        {
            get;
        }

        String Pseudo
        {
            get;
        }

        /// <summary>
        /// Indicate to not use this user anymore, cause of data peremption
        /// </summary>
        bool IsValid
        {
            get;
        }

        /// <summary>
        /// Invalidate the user's data, so it should'nt be use anymore
        /// </summary>
        void Invalidate();
    }
}
