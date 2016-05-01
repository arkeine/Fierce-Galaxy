namespace FierceGalaxyInterface
{
    public interface IReadOnlyNode
    {
        int InitialRessource
        {
            get;
        }
        
        int MaxRessource
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
