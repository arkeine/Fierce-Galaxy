using ConsoleApplication1.TimeModule;
using FierceGalaxyServer;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static int Main(string[] args)
        {
            var time = new FierceGalaxyServer.NetworkTime().GetNetworkTime();
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
            

            try
            {
                playerManager.CreatePlayer("toto", "tata", "publictoto");
                playerManager.CreatePlayer("titi", "tata", "publictiti");
                playerManager.CreatePlayer("tutu", "tata", "publictutu");
            }
            catch (Exception)
            {
                Console.WriteLine("Pseudo déjà utilisé!");
            }

            Console.WriteLine(playerManager.Login("toto", "tata").PublicPseudo + " loggued successfully");
            Console.ReadLine();

        }
    }
}
