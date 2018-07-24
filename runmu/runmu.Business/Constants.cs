using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public sealed class Constants
    {
        public static string DBCONN = "Data Source = runmu.db; Version=3;";
        public static string LONG_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public static string SHORT_DATE_FORMAT = "yyyy-MM-dd";
        public static string TIME_STAMP_FORMAT = "";
        public static string PAID = "已支付";
        public static string UNPAID = "未支付";
        public static string FULL = "全额";
        public static string DOWN_PAYMENT = "首付";
        public static string NO_ = "第{0:D2}期";

    }
}
