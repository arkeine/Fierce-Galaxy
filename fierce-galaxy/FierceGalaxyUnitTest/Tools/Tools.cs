using System;

namespace FierceGalaxyUnitTest
{
    class Tools
    {
        public static bool AreDoubleEqual(double d1, double d2, double epsylon = 0.001)
        {
            if (Math.Abs(d1 - d2) < epsylon)
            {
                return true;
            }
            else
            {
                Console.WriteLine("AreDoubleEqual : " + d1 + "=" + d2 + " Fail");
                return false;
            }
        }
    }
}
