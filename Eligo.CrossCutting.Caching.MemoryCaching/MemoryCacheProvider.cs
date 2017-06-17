using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Eligo.CrossCutting.Caching.MemoryCaching
{
    public class MemoryCacheProvider : ICacheProvider
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public object Get(string key)
        {
            return Get<object>(key);
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdded(string key)
        {
            return (Cache.Contains(key));
        }

        public void Remove(List<string> keys)
        {
            foreach (var key in keys)
            {
                Remove(key);
            }
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Set(string key, object data, TimeSpan cacheTime)
        {
            Set<object>(key, data, cacheTime);
        }

        public void Set<T>(string key, T data, TimeSpan cacheTime)
        {
            if (data == null)
            {
                return;
            }
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + cacheTime
            };

            Cache.Add(new CacheItem(key, data), policy);
        }
    }
}
