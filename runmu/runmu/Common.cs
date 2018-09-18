using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace runmu
{
    public class Common
    {
        public static long GetTimeStamp()
        {
            return GetTimeStamp(DateTime.Now);
        }

        public static long GetTimeStamp(DateTime time)
        {
            return (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

    }
}
