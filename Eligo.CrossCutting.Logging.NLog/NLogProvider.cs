using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Logging.NLog
{
    public class NLogProvider : ILogProvider
    {
        private readonly Logger log;
        
        public NLogProvider()
        {
            
        }

        public NLogProvider(Logger log)
        {
            this.log = log;
        }

        public void Debug(string message, params object[] args)
        {
            log.Debug(message, args);
        }

        public void Debug(string message, Exception exception, params object[] args)
        {
            message = string.Format(message, args);

            log.Debug(exception, message, args);
        }

        public void Debug(object item)
        {
            log.Debug(item);
        }

        public void Fatal(string message, params object[] args)
        {
            log.Fatal(message, args);
        }

        public void Fatal(string message, Exception exception, params object[] args)
        {
            message = string.Format(message, args);

            log.Fatal(exception, message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            log.Info(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            log.Warn(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            log.Error(message, args);
        }

        public void LogError(string message, Exception exception, params object[] args)
        {
            message = string.Format(message, args);

            log.Error(exception, message, args);
        }
    }
}
