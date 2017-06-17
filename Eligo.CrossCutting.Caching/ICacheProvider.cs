using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Caching
{
    public interface ICacheProvider
    {
        object Get(string key);
        T Get<T>(string key);

        bool IsAdded(string key);

        void Set<T>(string key, T data, TimeSpan cacheTime);
        void Set(string key, object data, TimeSpan cacheTime);

        void Clear();

        void Remove(List<string> keys);
        void Remove(string key);

        void RemoveByPattern(string pattern);
    }
}
