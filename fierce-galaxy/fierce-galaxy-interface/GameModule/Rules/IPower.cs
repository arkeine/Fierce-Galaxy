namespace FierceGalaxyInterface.GameModule.Board
{
    public interface IPower
    {
        string Name
        {
            get;
        }

        void Apply(IReadOnlyNode source, IReadOnlyNode target);
    }
}
