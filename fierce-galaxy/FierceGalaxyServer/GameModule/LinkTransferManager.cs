using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FierceGalaxyServer
{
    public class LinkTransferManager
    {
        //======================================================
        // Static
        //======================================================

        public static TimeSpan DefaultFunctionDistance(IReadOnlyNode n1, IReadOnlyNode n2)
        {
            double dx = n1.X - n2.X;
            double dy = n1.Y - n2.Y;

            double d = Math.Sqrt(dx * dx + dy * dy);
            d = d - n1.Radius - n2.Radius;

            /*
            Is there a possibility to do :

            double d = dx*dx+dy*dy;
            d = d - n1.Radius*n1.Radius - n2.Radius*n2.Radius;

            And change the method name to SquarDistanceBetweenNode ? 
            Aim : improve speed
            */

            return TimeSpan.FromSeconds(d / 10);
        }

        //======================================================
        // Delegate
        //======================================================

        public delegate TimeSpan FonctionDistance(IReadOnlyNode n1, IReadOnlyNode n2);

        //======================================================
        // Field
        //======================================================

        private FunctionDictionary<GameNode> nm;
        private SortedList<DateTime, Squad> listSquad;
        private FonctionDistance fd;

        //======================================================
        // Constructor
        //======================================================

        public LinkTransferManager(FunctionDictionary<GameNode> nm) :
            this(nm, DefaultFunctionDistance) { }

        public LinkTransferManager(FunctionDictionary<GameNode> nm, FonctionDistance fd)
        {
            this.nm = nm;
            this.fd = fd;
            listSquad = new SortedList<DateTime, Squad>();
        }

        //======================================================
        // Access
        //======================================================

        /// <summary>
        /// Send a squad to another node.
        /// </summary>
        public void SendSquad(int ressources,
            GameNode sourceNode, GameNode targetNode)
        {
            Squad s = CreateSquadFromNode(ressources, sourceNode);
            if (s.Ressources > 0)
            {
                s.TargetNode = targetNode;

                DateTime now = DateTime.Now;
                DateTime arrival = now + fd(s.SourceNode.NodeData, s.TargetNode.NodeData);
                DealRessources(now);
                listSquad.Add(arrival, s);
            }
        }

        /// <summary>
        /// Force the update and deal the ressources which are
        /// arrived to the node
        /// </summary>
        public void Update()
        {
            DealRessources(DateTime.Now);
        }
        
        //======================================================
        // Private
        //======================================================

        /// <summary>
        /// Deal the ressources of the squad in the targeted node
        /// </summary>
        private void SquadEnterNode(Squad s)
        {
            GameNode n = s.TargetNode;
            double v = nm.GetCurrentValue(n);

            if (s.CurrentOwner == n.CurrentOwner)
            {
                nm.SetCurrentValue(n, v + s.Ressources);
            }
            else
            {
                double diff = v - s.Ressources;
                if (diff < 0)
                {
                    nm.SetCurrentValue(n, -1 * diff);
                    n.CurrentOwner = s.CurrentOwner;
                }
                else
                {
                    nm.SetCurrentValue(n, diff);
                }
            }
        }

        private Squad CreateSquadFromNode(int ressources, GameNode sourceNode)
        {
            double available = nm.GetCurrentValue(sourceNode);
            double max = sourceNode.NodeData.MaxCapacity;
            available = available > max ? max : available;

            double toSend = available - ressources >= 0 ? ressources : available;

            nm.SetCurrentValue(sourceNode, available - toSend);

            Squad s = new Squad();
            s.CurrentOwner = sourceNode.CurrentOwner;
            s.Ressources = toSend;
            s.SourceNode = sourceNode;

            return s;
        }

        /// <summary>
        /// Deal the ressources to the node at the given time
        /// </summary>
        private void DealRessources(DateTime t)
        {
            var pair = GetFirstSquad();

            while (pair != null && pair.Value.Key <= t)
            {
                Squad s = pair.Value.Value;
                SquadEnterNode(s);

                //Load next element
                listSquad.Remove(pair.Value.Key);
                pair = GetFirstSquad();
            }
        }

        private Nullable<KeyValuePair<DateTime, Squad>> GetFirstSquad()
        {
            if (listSquad.Count <= 0) return null;
            else return listSquad.First();
        }

        //======================================================
        // Internal
        //======================================================

        private struct Squad
        {
            public double Ressources;
            public IReadOnlyPlayer CurrentOwner;
            public GameNode SourceNode;
            public GameNode TargetNode;
        }
    }
}