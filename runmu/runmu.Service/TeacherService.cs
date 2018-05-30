using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Service
{
    public class TeacherService : Service
    {
        private static string sql = "select id, name as '姓名' ,qq as 'QQ', alias as '昵称',email from teacher";

        protected override string GetSql()
        {
            return sql;
        }
    }
}
