using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Common
{
    public class Dictionary2D<K1, K2, V>
    {
        private Dictionary<K1, Dictionary<K2, V>> dict =
            new Dictionary<K1, Dictionary<K2, V>>();

        public V this[K1 key1, K2 key2]
        {
            get
            {
                try
                {
                    return dict[key1][key2];
                }
                catch
                {
                    return default(V);
                }
            }

            set
            {
                if (!dict.ContainsKey(key1))
                {
                    dict[key1] = new Dictionary<K2, V>();
                }
                dict[key1][key2] = value;
            }
        }
    }

    public class ItemDictionary : Dictionary2D<string, string, object>
    { }
}
