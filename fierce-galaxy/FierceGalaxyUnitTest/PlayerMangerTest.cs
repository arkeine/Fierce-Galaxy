using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;
using FierceGalaxyInterface;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class PlayerMangerTest
    {
        [TestMethod]
        public void CreatePlayerAndLogin()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = new PlayerManager(CreateNewDB());
            
            playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            IPlayer p = playerManager.Login(pseudo, playerPW);
            Assert.AreEqual(playerManager.Login(pseudo, playerPW).PublicPseudo, publicPseudo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Password for pseudo 'Dany' is incorrect")]
        public void LoginFailWrongPassword()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = new PlayerManager(CreateNewDB());

            playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            playerManager.Login(pseudo, "pass12");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Pseudo 'Dany' does not exist")]
        public void LoginFailPseudoDoesntExist()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = new PlayerManager(CreateNewDB());

            playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            playerManager.Login("Dani", playerPW);
        }

        private IDBManager CreateNewDB()
        {
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "\\DB.json";
  
            return new DBJsonManager(fileName);            
        }
    }
}
