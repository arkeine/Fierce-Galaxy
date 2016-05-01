using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client vara = new ServiceReference1.Service1Client();
            Console.WriteLine(vara.GetData(1));
            Console.ReadKey();
        }
    }
}
