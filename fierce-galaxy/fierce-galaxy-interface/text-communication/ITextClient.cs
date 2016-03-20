using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace fierce_galaxy_interface.text_communication
{
    interface ITextClient
    {
        void sendMessage(IPAddress ip, int port, String message);
    }
}
