using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Caching.MemoryCaching
{
    public class MemoryCacheFactory : ICacheFactory
    {
        public ICacheProvider Create()
        {
            return new RedisCacheProvider();
        }
    }
}
