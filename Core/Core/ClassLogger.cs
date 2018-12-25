using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core
{
    public class ClassLogger
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public void LogBebug(string logger)
        {
            log.Debug(logger);
        }
    }
}
