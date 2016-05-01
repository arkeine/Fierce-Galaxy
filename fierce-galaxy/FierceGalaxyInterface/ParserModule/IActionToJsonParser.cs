namespace FierceGalaxyInterface
{
    public interface IGameActionParser
    {
        void JsonToAction(string json);
        
        // Action from the game module

        void NodeUpdating(IReadOnlyNode node, IReadOnlyPlayer owner, double ressourcesOffset);

        void SquadLeaving(IReadOnlyNode sourceNode, IReadOnlyNode targetNode, IReadOnlyPlayer owner, double ressources);

        void ManaUpdating(IReadOnlyPlayer player, double currentAmount);

        void GameFinishing();
    }
}
