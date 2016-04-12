using FierceGalaxyInterface;
using System;
using FierceGalaxyInterface.ConnexionModule;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    public class Node : INode
    {
        //======================================================
        // Properties
        //======================================================

        public List<Node> ListLinkedNodes { get; set; }

        public int CurrentCapacity { get; set; }

        public IPlayer CurrentOwner { get; set; }

        public int InitialCapacity { get; set; }

        public int MaxCapacity { get; set; }

        public double Radius { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        //======================================================
        // Private
        //======================================================

    }
}