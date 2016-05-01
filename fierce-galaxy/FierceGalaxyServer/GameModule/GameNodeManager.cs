using System;
using System.Collections.Generic;

namespace FierceGalaxyServer.GameModule
{
    /// <summary>
    /// Manage the value of node in function of time
    /// </summary>
    class GameNodeManager
    {
        //======================================================
        // Delegate
        //======================================================

        public delegate double Fonction(double t);

        //======================================================
        // Field
        //======================================================

        private IDictionary<GameNode, double> dicOffset;
        private DateTime zero;
        private Fonction f;

        //======================================================
        // Constructor
        //======================================================

        public GameNodeManager(Fonction f)
        {
            dicOffset = new Dictionary<GameNode, double>();
            Zero = DateTime.Now;
            Function = f;
        }

        public GameNodeManager() : this(delegate (double t) { return t; }) { }

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

        public Fonction Function
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

        public void SetCurrentValue(GameNode n, double ressources)
        {
            //Calculate the value to substract to offset
            double newOffset = GetValueFromZero() - ressources;
            
            //Update the offset
            dicOffset[n] = newOffset;
        }

        public double GetCurrentValue(GameNode n)
        {
            double absolutValue = Function((DateTime.Now - zero).TotalSeconds);
            return GetValueFromZero() - GetCurrentOffset(n);
        }

        public double GetCurrentOffset(GameNode n)
        {
            double currentOffset;
            dicOffset.TryGetValue(n, out currentOffset);
            return currentOffset;
        }

        //======================================================
        // Private
        //======================================================

        private double GetValueFromZero()
        {
            return Function((DateTime.Now - zero).TotalSeconds);
        }
    }
}