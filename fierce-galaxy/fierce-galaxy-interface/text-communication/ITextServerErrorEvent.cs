using fierce_galaxy_interface.text_communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace fierce_galaxy_interface
{
    interface ITextServerErrorEvent : ITextServerEvent
    {
        Exception Exception
        {
            get;
        }
    }
}
