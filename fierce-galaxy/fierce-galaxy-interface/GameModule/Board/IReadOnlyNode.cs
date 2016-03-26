using System.Collections.Generic;

namespace FierceGalaxyInterface.GameModule
{
    public interface IReadOnlyNode
    {
        IReadOnlyList<ILink> Links
        {
            get;
        }

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
