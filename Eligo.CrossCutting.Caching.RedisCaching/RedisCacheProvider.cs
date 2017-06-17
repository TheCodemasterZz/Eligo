using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Eligo.CrossCutting.Caching.MemoryCaching
{
    public class RedisCacheProvider : ICacheProvider
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool IsAdded(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(List<string> keys)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data, TimeSpan cacheTime)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T data, TimeSpan cacheTime)
        {
            throw new NotImplementedException();
        }
    }
}
