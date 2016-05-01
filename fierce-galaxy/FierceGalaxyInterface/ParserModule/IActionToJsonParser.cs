namespace FierceGalaxyInterface
{
    public delegate void SendJson(IReadOnlyPlayer node, string json);

    public interface IGameActionParser
    {
        event SendJson SendingJson;

        // Action from the game module

        void NodeUpdating(IReadOnlyNode node, IReadOnlyPlayer owner, double ressourcesOffset);

        void SquadLeaving(IReadOnlyNode sourceNode, IReadOnlyNode targetNode, IReadOnlyPlayer owner, double ressources);

        void ManaUpdating(IReadOnlyPlayer player, double currentAmount);

        void GameFinishing();
    }
}
