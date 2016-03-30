using FierceGalaxyInterface.ConnexionModule;
using System;

namespace FierceGalaxyInterface.GameModule
{
    public interface INodeUpdate
    {
        IReadOnlyNode Node
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
