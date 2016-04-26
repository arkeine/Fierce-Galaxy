using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FierceGalaxyServer.GameModule
{
    public class LinkTransferManager
    {
        //======================================================
        // Field
        //======================================================

        private FunctionDictionary<GameNode> nm;
        private SortedList<DateTime, Squad> listSquad;

        //======================================================
        // Constructor
        //======================================================

        public LinkTransferManager(FunctionDictionary<GameNode> nm)
        {
            this.nm = nm;
            listSquad = new SortedList<DateTime, Squad>();
        }

        //======================================================
        // Access
        //======================================================

        /// <summary>
        /// Send a squad to another node.
        /// </summary>
        public void SendSquad(
            int ressources, IReadOnlyPlayer currentOwner, 
            GameNode sourceNode, GameNode targetNode)
        {
            Squad s;
            s.Ressources = ressources;
            s.CurrentOwner = currentOwner;
            s.SourceNode = sourceNode;
            s.TargetNode = targetNode;

            DateTime now = DateTime.Now;
            DateTime arrival = now + TravelTime(s.SourceNode, s.TargetNode);
            DealRessources(now);
            listSquad.Add(arrival, s);
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

        /// <summary>
        /// Deal the ressources to the node at the given time
        /// </summary>
        private void DealRessources(DateTime t)
        {
            KeyValuePair<DateTime, Squad> pair = listSquad.First();

            while (pair.Key <= t)
            {
                Squad s = pair.Value;
                SquadEnterNode(s);

                //Load next element
                listSquad.Remove(pair.Key);
                pair = listSquad.First();
            }
        }

        private TimeSpan TravelTime(GameNode sourceNode, GameNode targetNode)
        {
            double d = DistanceBetweenNode(sourceNode.NodeData, targetNode.NodeData);

            return TimeSpan.FromSeconds(d * 10);
        }

        private double DistanceBetweenNode(IReadOnlyNode n1, IReadOnlyNode n2)
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

            return d >= 0 ? d : 0;
        }

        //======================================================
        // Internal
        //======================================================

        private struct Squad
        {
            public int Ressources;
            public IReadOnlyPlayer CurrentOwner;
            public GameNode SourceNode;
            public GameNode TargetNode;
        }
    }
}