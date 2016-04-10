using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PlayerMangerTest
    {
        [TestMethod]
        public void t01_createPlayer_pseudoDoesntExist()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = PlayerManager.GetInstance();

            if (playerManager.MapDBPlayers.ContainsKey(pseudo))
                playerManager.MapDBPlayers.Remove(pseudo);

            try
            {
                playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            }
            catch (Exception)
            {
                Console.WriteLine("Pseudo déjà utilisé!");
            }
            Assert.IsTrue(playerManager.MapDBPlayers.ContainsKey(pseudo));
        }

        [TestMethod]
        public void t02_loginSuccess()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = PlayerManager.GetInstance();

            try
            {
                playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(playerManager.Login(pseudo, playerPW).PublicPseudo, publicPseudo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Password for pseudo 'Dany' is incorrect")]
        public void t03_loginFail_WrongPassword()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = PlayerManager.GetInstance();

            try
            {
                playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            }
            catch (Exception)
            {
            }
            playerManager.Login(pseudo, "pass12");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Pseudo 'Dany' does not exist")]
        public void t04_loginFail_PseudoDoesntExist()
        {
            string pseudo = "Dany";
            string playerPW = "pass123";
            string publicPseudo = "shotgun";
            PlayerManager playerManager = PlayerManager.GetInstance();

            try
            {
                playerManager.CreatePlayer(pseudo, playerPW, publicPseudo);
            }
            catch (Exception)
            {
            }
            playerManager.Login("Dani", playerPW);
        }

    }
}
