using FierceGalaxyInterface.ConnexionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FierceGalaxyInterface.GameModule
{
    public interface IRulesManager
    {

        void SetPairs(INode n1, INode n2);
        void SendRessources(IReadOnlyNode source, int amount);
        void SendRessources(ILink node);
        void ReciveRessourcesFrom(IPlayer owner, int amount);
        IReadOnlyList<IReadOnlyPlayer> Players
        {
            get;
        }

        void AddPlayer(IReadOnlyPlayer player);











        event EventHandler<INodeUpdate> NodeUpdate;
        event EventHandler<ILinkEnterUpdate> LinkEnterUpdate;
        event EventHandler<IPowerUpdate> PowerUpdate;

        DateTime TimeOffset
        {
            get;
            set;
        }

        IReadOnlyList<IReadOnlyPlayer> Players
        {
            get;
        }

        void SendSquad(IReadOnlyPlayer player, IReadOnlyNode source, int amount);
        void UsePower(IReadOnlyPlayer player, IReadOnlyNode source, IReadOnlyNode target);
        void SendSquad(IReadOnlyPlayer player, IReadOnlyNode source, int amount);
    }
}
