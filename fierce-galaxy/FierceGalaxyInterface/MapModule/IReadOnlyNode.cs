namespace FierceGalaxyInterface
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
