using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyServer;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class PlayerMangerTest
    {
        //======================================================
        // Test case
        //======================================================

        [TestMethod]
        public void CreatePlayerAndLogin()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Password for pseudo 'Dany' is incorrect")]
        public void LoginFailWrongPassword()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = new PlayerManager();

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
            PlayerManager playerManager = new PlayerManager();

            playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            playerManager.Login("Dani", playerPW);
        }
    }
}
