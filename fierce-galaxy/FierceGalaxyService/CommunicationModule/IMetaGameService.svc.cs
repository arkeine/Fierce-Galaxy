using System;

namespace FierceGalaxyServer
{
    public class MetaGameService : IMetaGameService
    {
        public void NewPlayer(string pseudo, string playerPW, string publicPseudo)
        {
            GameFacade.GetInstance().PlayerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
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
