using System.Collections.Generic;

namespace FierceGalaxyServer
{
    /// <summary>
    /// Manage the correspondence between two unique value
    /// </summary>
    public class DoubleDictionarySameType<A>
    {
        //======================================================
        // Field
        //======================================================

        //This two dictionary work like one where keys and values are both unique
        private IDictionary<A, A> mapAtoB = new Dictionary<A, A>();
        private IDictionary<A, A> mapBtoA = new Dictionary<A, A>();

        //======================================================
        // Accessor/Mutator
        //======================================================

        public bool Add(A a, A b)
        {
            if (!mapAtoB.ContainsKey(a) &&
                !mapBtoA.ContainsKey(b))
            {
                mapAtoB[a] = b;
                mapBtoA[b] = a;

                return true;
            }
            return false;
        }
        

        public bool Remove(A a)
        {
            if (mapAtoB.ContainsKey(a))
            {
                mapBtoA.Remove(mapAtoB[a]);
                mapAtoB.Remove(a);

                return true;
            }

            return false;
        }

        
        public A GetOther(A a)
        {
            return mapAtoB[a];
        }

        public bool Contains(A a)
        {
            return mapAtoB.ContainsKey(a);
        }
        
    }
}