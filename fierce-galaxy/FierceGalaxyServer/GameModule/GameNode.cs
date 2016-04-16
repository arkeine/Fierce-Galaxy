using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FierceGalaxyServer
{
    class GameNode
    {
        int CurrentCapacity { get; set; }
        IReadOnlyPlayer CurrentOwner { get; set; }
    }
}
