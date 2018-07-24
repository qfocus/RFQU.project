using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class SignUpService : Service
    {
        private static string tableName = "`signup`";
        private static string selectAllSql =
            @"select s.ID, c.name as '课程', st.name as '学员',st.ID as 'QQ', s.signDate as '报名日期',s.expire as '指导期', s.payType as '付款方式', a.name as '销售',ls.name as '状态' from signup as s
            join course as c on s.courseID = c.ID
            join students as st on s.studentID = st.ID
            join assistant as a on s.assistantID = a.ID
            join learnStatus as ls on s.statusID = ls.ID;";

        private static string insertSql =
            @"INSERT INTO `signup`
            (`courseID`,`studentID`,`assistantID`,`signDate`,`expireDate`, `expire`, `payType`,`platformID`,`statusID`,`createdTime`,`updateTime`) VALUES 
            (@courseID, @studentID, @assistantID, @signDate, @expireDate, @expire, @payType, @platformID, @statusID, @date, @date);";


        private static string querySql = @"SELECT `ID`, `signDate`, `expire` FROM `signup` WHERE ";

        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override SQLiteParameter[] BuildInsertParameters(params Args[] values)
        {
            return BuildDefaultOperateParams(values);
        }

        protected override SQLiteParameter[] BuildQueryParameters(params Args[] values)
        {
            return BuildDefaultParams(values).ToArray();
        }

        protected override string GetInsertSql()
        {
            return insertSql;
        }


        protected override string GetQuerySql()
        {
            return querySql;
        }

        protected override string GetSelectAllSql()
        {
            return selectAllSql;
        }

        protected override string TableName()
        {
            return tableName;
        }
    }
}
