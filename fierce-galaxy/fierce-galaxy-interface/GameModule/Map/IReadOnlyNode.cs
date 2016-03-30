using FierceGalaxyInterface.ConnexionModule;
using System.Collections.Generic;

namespace FierceGalaxyInterface.GameModule
{
    public interface IReadOnlyNode
    {
        int InitialCapacity
        {
            get;
        }

        int MaxCapacity
        {
            get;
        }

        int CurrentCapacity
        {
            get;
        }

        IPlayer CurrentOwner
        {
            get;
        }

        double X
        {
            get;
        }

        double Y
        {
            get;
        }

        double Radius
        {
            get;
        }
    }
}
