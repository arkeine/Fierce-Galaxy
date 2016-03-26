namespace FierceGalaxyInterface.GameModule
{
    public interface ILink : IReadOnlyLink
    {
        void SetPairs(INode n1, INode n2);

        void SendRessources(IReadOnlyNode input, int amount);
    }
}
