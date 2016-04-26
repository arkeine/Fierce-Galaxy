using FierceGalaxyInterface;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    public class Node : INode
    {
        //======================================================
        // Properties
        //======================================================

        public List<Node> ListLinkedNodes { get; set; }

        public IPlayer CurrentOwner { get; set; }

        public int InitialRessource { get; set; }

        public int MaxRessource { get; set; }

        public double Radius { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        //======================================================
        // Constructor
        //======================================================

        public Node(IPlayer owner = null,
            int initialCapacity = 20, 
            int maxCapacity = 50,
            double radius = 1.0,
            double x = 0.0,
            double y = 0.0)
        {

        }

        //======================================================
        // Private
        //======================================================

    }
}