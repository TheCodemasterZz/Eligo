using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Logging.NLog
{
    public class NLogFactory : ILogFactory
    {
        public ILogProvider Create()
        {
            return new NLogProvider();
        }
    }
}
