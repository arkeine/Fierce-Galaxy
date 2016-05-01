using System.Collections.Generic;

namespace FierceGalaxyServer
{
    /// <summary>
    /// Dictionary with multiple value for a key
    /// 
    /// source: http://www.dotnetperls.com/multimap
    /// </summary>
    public class MultiMap<K, V>
    {
        //======================================================
        // Field
        //======================================================

        private Dictionary<K, List<V>> dictionary;

        //======================================================
        // Constructor
        //======================================================

        public MultiMap()
        {
            dictionary = new Dictionary<K, List<V>>();
        }

        //======================================================
        // Access
        //======================================================

        public void Add(K key, V value)
        {
            List<V> list;

            if (dictionary.TryGetValue(key, out list))
            {
                list.Add(value);
            }
            else
            {
                list = new List<V>(); //TODO check if necessary
                list.Add(value);
                dictionary[key] = list;
            }
        }

        public void RemoveValueInKey(K key, V value)
        {
            List<V> list;

            if (this.dictionary.TryGetValue(key, out list))
            {
                list.Remove(value);
            }
        }

        public void RemoveKey(K key)
        {
            dictionary.Remove(key);
        }

        public bool Contains(K key, V value)
        {
            List<V> list;

            if (dictionary.TryGetValue(key, out list))
            {
                return list.Contains(value);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                return dictionary.Keys;
            }
        }

        public List<V> this[K key]
        {
            get
            {
                List<V> list;
                if (!dictionary.TryGetValue(key, out list))
                {
                    list = new List<V>();
                    this.dictionary[key] = list;
                }
                return list;
            }
        }
    }
}