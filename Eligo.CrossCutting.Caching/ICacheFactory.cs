using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Caching
{
    public interface ICacheFactory
    {
        ICacheProvider Create();
    }
}
