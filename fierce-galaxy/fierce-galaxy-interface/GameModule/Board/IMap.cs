namespace FierceGalaxyInterface.GameModule
{
    public interface IMap : IReadOnlyMap
    {
        void AddNode(IReadOnlyNode node);

        void AddSpawnNode(IReadOnlyNode node);

        void RemoveNode(IReadOnlyNode node);
    }
}
