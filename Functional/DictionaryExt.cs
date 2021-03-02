using System.Collections.Generic;

using static Functional.Fun;

namespace Functional
{
    public static class DictionaryExt
    {
        public static Option<T> Lookup<K, T>(this IDictionary<K, T> dict, K key)
        {
            return dict.TryGetValue(key, out var value) ? Some(value) : None;
        }
    }
}