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
            
            return 0;

        }
    }
}
