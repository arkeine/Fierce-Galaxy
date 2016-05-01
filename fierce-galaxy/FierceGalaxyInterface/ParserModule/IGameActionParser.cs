namespace FierceGalaxyInterface
{
    public interface IGameActionParser
    {
        void 
        void Move(string token, string sourceNodeID, string targetNodeID, string ressources);
        
        void UsePowerDestroy(string token, string targetNodeID);
        
        void UsePowerInvincibility(string token, string targetNodeID);
        
        void UsePowerArmor(string token, string targetNodeID);
        
        void UsePowerTeleportation(string token, string sourceNodeID, string targetNodeID, string ressources);

        string ListLobbies(string token);

        void Join(string token, string lobbyID);
    }
}
