using System;
using System.Collections.Generic;

namespace FierceGalaxyServer
{
    /// <summary>
    /// Manage a key-value pair where the value is function of 
    /// time
    /// </summary>
    public class FunctionDictionary<T>
    {
        //======================================================
        // Delegate
        //======================================================

        public delegate double Fonction(double t);

        //======================================================
        // Field
        //======================================================

        private IDictionary<T, double> dicOffset;
        private DateTime zero;
        private Fonction f;

        //======================================================
        // Constructor
        //======================================================

        public FunctionDictionary(Fonction f)
        {
            dicOffset = new Dictionary<T, double>();
            Zero = DateTime.Now;
            Function = f;
        }

        public FunctionDictionary() : this(delegate (double t) { return t; }) { }

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

        public void SetCurrentValue(T k, double ressources)
        {
            //Calculate the value to substract to offset
            double newOffset = GetValueFromZero() - ressources;

            //Update the offset
            dicOffset[k] = Math.Abs(newOffset);
        }

        public double GetCurrentValue(T k)
        {
            double absolutValue = Function((DateTime.Now - zero).TotalSeconds);
            double currentOffset;
            dicOffset.TryGetValue(k, out currentOffset);
            return GetValueFromZero() - currentOffset;
        }

        //======================================================
        // Private
        //======================================================

        private double GetValueFromZero()
        {
            return (int)Function((DateTime.Now - zero).TotalSeconds);
        }
    }
}