using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Caching
{
    public static class CacheFactory
    {
        static ICacheFactory _currentCacheFactory = null;

        public static void SetCurrent(ICacheFactory cacheFactory)
        {
            _currentCacheFactory = cacheFactory;
        }

        public static ICacheProvider Create()
        {
            return (_currentCacheFactory != null) ? _currentCacheFactory.Create() : null;
        }
    }
}
