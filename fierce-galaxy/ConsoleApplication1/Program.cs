using ConsoleApplication1.TimeModule;
using System;
using FierceGalaxyServer.ConnexionModule;

namespace ConsoleApplication1
{
    class Program
    {
        static int Main(string[] args)
        {
            var time = new NetworkTime().GetNetworkTime();
            var myTime = DateTime.Now;
            var diffTime = time - myTime;
            
            //Console.WriteLine(time.ToString() + " / diff : " +diffTime.TotalMilliseconds.ToString());
            //Console.ReadLine();

            testUser();
            return 0;

        }

        private static void testUser()
        {

            PlayerManager playerManager = PlayerManager.GetInstance();

            playerManager.CreatePlayer("toto", "tata", "publictoto");
            playerManager.CreatePlayer("titi", "tata", "publictoto");
            playerManager.CreatePlayer("tutu", "tata", "publictoto");

            Console.WriteLine(playerManager.Login("toto", "tata").PublicPseudo + " loogued successfully");
            Console.ReadLine();

        }
    }
}
