using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Util
{
    public class Log
    {
        public static readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        //public void TraceError(string message)
        //{
        //    logger.Error(message);
        //    //logger.Error(string.Format("{0}| Method : {1} | Message : {2} {3}", id, objectName, message, stackTrace));
        //}
    }
}
