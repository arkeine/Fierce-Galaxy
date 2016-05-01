using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FierceGalaxyService.ServicesWithLogin
{
    public class FierceGalaxyLoggedIn : IFierceGalaxyLoggedIn
    {
        public void Connect()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Connect");
        }

        public void Disconnect()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Disconnect");
        }

        public string GenerateConnexionToken()
        {
            //throw new NotImplementedException();
            Console.WriteLine("GenerateConnexionToken");
            return "TROOLLLLLL";
        }
    }
}
