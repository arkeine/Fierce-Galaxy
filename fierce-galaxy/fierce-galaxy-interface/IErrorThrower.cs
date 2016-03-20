using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fierce_galaxy_interface.text_communication
{
    /// <summary>
    /// Should be implement by class which need to throw exception asynchronly 
    /// </summary>
    interface IErrorThrower
    {
        event EventHandler<ITextServerErrorEvent> ErrorReceive;
    }
}
