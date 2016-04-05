using FierceGalaxyInterface.ConnexionModule;

namespace FierceGalaxyInterface.MapModule
{
    public interface INode : IReadOnlyNode
    {
        new int InitialCapacity
        {
            get;
            set;
        }

        new int MaxCapacity
        {
            get;
            set;
        }

        new int CurrentCapacity
        {
            get;
            set;
        }

        new IPlayer CurrentOwner
        {
            get;
            set;
        }

        new double X
        {
            get;
            set;
        }

        new double Y
        {
            get;
            set;
        }

        new double Radius
        {
            get;
            set;
        }
    }
}
