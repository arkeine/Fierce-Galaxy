using FierceGalaxyInterface.ConnexionModule;
using System;

namespace FierceGalaxyInterface.GameModule
{
    public interface ILinkEnterUpdate
    {
        IReadOnlyLink Link
        {
            get;
        }

        IReadOnlyNode StartNode
        {
            get;
        }

        DateTime TimeStamp
        {
            get;
        }

        IReadOnlyPlayer Owner
        {
            get;
        }

        int Ressources
        {
            get;
        }
    }
}