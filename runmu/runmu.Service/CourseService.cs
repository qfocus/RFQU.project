using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Service
{
    public class CourseService : Service
    {
        private static string sql = @"select c.ID, c.teacherID, c.name as '课程', c.price as '价格', t.name as '教师' from course as c join teacher as t on c.teacherId =  t.id";

        protected override string SelectAllSql()
        {
            return sql;
        }
    }
}
