using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace runmu
{
    public class Logger
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("runmu");


        public static void Error(Exception exception)
        {
            logger.Error("error", exception);
        }

        public static void Warnning(List<string> message)
        {
            foreach (var item in message)
            {
                logger.Warn(item);
            }
        }
    }
}
