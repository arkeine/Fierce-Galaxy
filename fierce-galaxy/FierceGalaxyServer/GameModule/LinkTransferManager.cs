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
            listSquad = new SortedList<DateTime, Squad>(new DuplicateKeyComparer<DateTime>());
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
                AddSquadToList(arrival, s);
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
            double max = sourceNode.NodeData.MaxRessource;
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
                listSquad.RemoveAt(0);
                pair = GetFirstSquad();
            }
        }

        private Nullable<KeyValuePair<DateTime, Squad>> GetFirstSquad()
        {
            if (listSquad.Count == 0)
            {
                return null;
            }
            else return listSquad.First();
        }

        private void AddSquadToList(DateTime arrival, Squad newSquad)
        {
            int i = listSquad.Count-1;

            while (i >= 0)
            {
                var k = listSquad.ElementAt(i);

                Squad otherSquad = k.Value;

                if (newSquad.SourceNode == otherSquad.TargetNode &&
                    newSquad.CurrentOwner != otherSquad.CurrentOwner)
                {
                    //Resolve the fight between squad
                    if (newSquad.Ressources < otherSquad.Ressources)
                    {
                        otherSquad.Ressources -= newSquad.Ressources;
                        newSquad.Ressources = 0;
                    }
                    else
                    {
                        newSquad.Ressources -= otherSquad.Ressources;
                        otherSquad.Ressources = 0;
                    }

                    //Update the list
                    if (otherSquad.Ressources <= 0)
                    {
                        listSquad.Remove(k.Key);
                    }
                    if (newSquad.Ressources <= 0)
                    {
                        return; //Return to save time
                    }
                }

                i -= 1;
            }
            
            listSquad.Add(arrival, newSquad);
        }

        //======================================================
        // Internal
        //======================================================

        private class Squad
        {
            public double Ressources;
            public IReadOnlyPlayer CurrentOwner;
            public GameNode SourceNode;
            public GameNode TargetNode;
        }
        /// <summary>
        /// Comparer for comparing two keys, handling equality
        /// as beeing greater
        /// Use this Comparer e.g. with SortedLists or 
        /// SortedDictionaries, that don't allow duplicate keys
        /// 
        /// Source :http://stackoverflow.com/questions/5716423/c-sharp-sortable-collection-which-allows-duplicate-keys
        /// </summary>
        public class DuplicateKeyComparer<TKey> : 
            IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return 1;   // Handle equality as beeing greater
                else
                    return result;
            }
        }
    }
}