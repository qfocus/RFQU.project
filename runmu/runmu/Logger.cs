using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace runmu
{
    public class Logger
    {
        public static readonly log4net.ILog logger = log4net.LogManager.GetLogger("runmu");


        public static void Error(Exception exception)
        {
            logger.Error("error", exception);
        }
    }
}
