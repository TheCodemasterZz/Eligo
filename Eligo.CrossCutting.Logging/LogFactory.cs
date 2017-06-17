using Eligo.CrossCutting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Logging
{
    public static class LogFactory
    {
        static ILogFactory _currentLogFactory = null;

        public static void SetCurrent(ILogFactory logFactory)
        {
            _currentLogFactory = logFactory;
        }

        public static ILogProvider Create()
        {
            return (_currentLogFactory != null) ? _currentLogFactory.Create() : null;
        }
    }
}
