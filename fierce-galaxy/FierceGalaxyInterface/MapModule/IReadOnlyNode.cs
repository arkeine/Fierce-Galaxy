using FierceGalaxyInterface.ConnexionModule;

namespace FierceGalaxyInterface.MapModule
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
