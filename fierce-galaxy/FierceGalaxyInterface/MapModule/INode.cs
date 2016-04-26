namespace FierceGalaxyInterface
{
    public interface INode : IReadOnlyNode
    {
        new int InitialRessource
        {
            get;
            set;
        }

        new int MaxRessource
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
