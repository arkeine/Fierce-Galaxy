using FierceGalaxyInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FierceGalaxyServer
{
    /// <summary>
    /// List which manage the ressources of the node in function of time
    /// </summary>
    public class NodeManager
    {
        //======================================================
        // Delegate
        //======================================================

        public delegate double NodeFonction(double t);

        //======================================================
        // Field
        //======================================================

        private IDictionary<IReadOnlyNode, int> dicOffset;
        private DateTime zero;
        private NodeFonction f;

        //======================================================
        // Constructor
        //======================================================

        public NodeManager(NodeFonction f)
        {
            dicOffset = new Dictionary<IReadOnlyNode, int>();
            Zero = DateTime.Now;
            Function = f;
        }

        public NodeManager() : this(delegate (double t) { return t; }) { }

        //======================================================
        // Access
        //======================================================

        public DateTime Zero
        {
            get
            {
                return zero;
            }

            set
            {
                zero = value;
            }
        }

        public NodeFonction Function
        {
            get
            {
                return f;
            }

            set
            {
                f = value;
            }
        }

        public void SetCurrentNodeRessources(IReadOnlyNode node, int ressources)
        {
            //Calculate the value to substract to offset
            int newOffset = GetRessourcesFromZero() - ressources;

            //Update the offset
            dicOffset[node] = Math.Abs(newOffset);
        }

        public int GetCurrentNodeRessources(IReadOnlyNode node)
        {
            int absolutValue = (int)Function((DateTime.Now - zero).TotalSeconds);
            int currentOffset;
            dicOffset.TryGetValue(node, out currentOffset);
            /*
            Console.WriteLine("GetCurrentRessources");
            Console.WriteLine("Abs "+absolutValue);
            Console.WriteLine("Cur "+currentOffset);
            Console.WriteLine("Dif "+(absolutValue - currentOffset));/**/
            return GetRessourcesFromZero() - currentOffset;
        }

        //======================================================
        // Private
        //======================================================

        private int GetRessourcesFromZero()
        {
            return (int)Function((DateTime.Now - zero).TotalSeconds);
        }
    }
}