using System.Collections.Generic;

namespace FierceGalaxyServer
{
    /// <summary>
    /// Manage the correspondence between two unique value
    /// </summary>
    public class DoubleDictionary<A, B>
    {
        //======================================================
        // Field
        //======================================================

        //This two dictionary work like one where keys and values are both unique
        private IDictionary<A, B> mapAtoB = new Dictionary<A, B>();
        private IDictionary<B, A> mapBtoA = new Dictionary<B, A>();

        //======================================================
        // Accessor/Mutator
        //======================================================

        public bool Add(B b, A a)
        {
            return Add(a, b);
        }

        public bool Add(A a, B b)
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
            if (!mapAtoB.ContainsKey(a))
            {
                mapBtoA.Remove(mapAtoB[a]);
                mapAtoB.Remove(a);

                return true;
            }

            return false;
        }

        public bool Remove(B b)
        {
            if (!mapBtoA.ContainsKey(b))
            {
                mapAtoB.Remove(mapBtoA[b]);
                mapBtoA.Remove(b);

                return true;
            }

            return false;
        }

        public B GetOther(A a)
        {
            return mapAtoB[a];
        }

        public A GetOther(B b)
        {
            return mapBtoA[b];
        }

        public bool Contains(A a)
        {
            return mapAtoB.ContainsKey(a);
        }

        public bool Contains(B b)
        {
            return mapBtoA.ContainsKey(b);
        }
    }
}