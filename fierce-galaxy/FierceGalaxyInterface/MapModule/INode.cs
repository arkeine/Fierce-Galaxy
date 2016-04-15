namespace FierceGalaxyInterface
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
