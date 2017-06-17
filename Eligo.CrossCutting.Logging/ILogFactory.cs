using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Logging
{
    public interface ILogFactory
    {
        ILogProvider Create();
    }
}
