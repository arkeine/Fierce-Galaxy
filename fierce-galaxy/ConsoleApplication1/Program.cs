using ConsoleApplication1.TimeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int Main(string[] args)
        {
            var time = new NetworkTime().GetNetworkTime();
            var myTime = DateTime.Now;
            var diffTime = time - myTime;
            
            Console.WriteLine(time.ToString() + " / diff : " +diffTime.TotalMilliseconds.ToString());
            Console.ReadLine();
            return 0;
        }
    }
}
