using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static class DictionaryEx
    {
        public static TValue GetOrNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TKey : class
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return default(TValue);
        }
    }
}
