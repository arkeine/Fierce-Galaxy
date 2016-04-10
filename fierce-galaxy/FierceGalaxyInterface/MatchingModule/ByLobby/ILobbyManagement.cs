using System.Collections.Generic;

namespace FierceGalaxyInterface
{
    /// <summary>
    /// Manage the custom lobby
    /// </summary>
    public interface ILobbyManagement
    {
        ILobby CreateLobby();

        void DeleteLobby(ILobby lobby);

        IReadOnlyList<ILobby> GetLobbyList();    
    }
}
