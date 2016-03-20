using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fierce_galaxy_interface
{
    interface ITextServer
    {
        bool initTextServer(int port);
        event EventHandler<ITextServerReceiveMessageEvent> MessageReceive;
    }
}
