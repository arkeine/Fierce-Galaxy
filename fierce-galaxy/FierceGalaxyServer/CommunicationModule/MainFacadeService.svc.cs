using System;
using FierceGalaxyServer.ConnexionModule;

namespace FierceGalaxyServer.CommunicationModule
{
    public class MainFacadeService : IMainFacadeService
    {
        public void NewPlayer(string pseudo, string playerPW, string publicPseudo)
        {
            PlayerManager.GetInstance().CreatePlayer(pseudo, playerPW, publicPseudo);
            throw new NotImplementedException();
        }

        public void Connect(string playerID, string playerPW)
        {
            throw new NotImplementedException();
        }
        
        public long GenerateConnexionToken()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
