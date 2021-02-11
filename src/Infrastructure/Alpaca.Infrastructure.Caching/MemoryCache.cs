using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Alpaca.Infrastructure.Caching
{
    public class MemoryCache<TKey, TValue> : IDisposable
    {
        private ConcurrentDictionary<TKey, TValue> _dicCache = new ConcurrentDictionary<TKey, TValue>();

        public bool Get(TKey key, out TValue value)
        {
            bool result = _dicCache.TryGetValue(key, out value);

            return result;
        }

        public List<TKey> GetAllKeyList()
        {
            return _dicCache.Keys.ToList();
        }

        public List<TValue> GetAllValueList()
        {
            var result = _dicCache.Values.ToList();

            return result;
        }

        public bool TryAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            return _dicCache.TryAdd(key, valueFactory(key));
        }

        public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue value;
            if (!_dicCache.TryGetValue(key, out value))
            {
                value = _dicCache.GetOrAdd(key, k => valueFactory(k));
            }

            return value;
        }

        public TValue AddOrUpdate(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue value = valueFactory(key);

            return _dicCache.AddOrUpdate
            (
                key,
                k => value,
                (oldkey, oldvalue) => value
            );
        }

        public bool Remove(TKey key)
        {
            TValue value;

            return _dicCache.TryRemove(key, out value);
        }

        public bool ContainsKey(TKey key)
        {
            return _dicCache.ContainsKey(key);
        }

        public void Clear()
        {
            _dicCache.Clear();
        }

        public void Dispose()
        {
            _dicCache.Clear();
            _dicCache = null;
        }
    }
}
