using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runmu.Business
{
    public class PaymentService : Service
    {

        private static string tableName = "`payment`";
        private static string insertSql =
            @"insert into `payment`
            (`courseID`,`studentID`,`payType`,`values`,`status`,`payDate`,`expire`, updateTime, createdTime)
            values
            (@courseID, @studentID, @payType, @values, @status, @payDate, @expire, @date, @date)";

        private static string selectAllSql =
            @"select p.ID, s.ID, c.name as '课程',s.name as '学员', p.payType as '类型' , p.`values` as '金额', p.status as '状态',p.payDate as '日期' from payment as p
            join course as c on p.courseID = c.ID
            join students as s on p.studentID = s.ID";


        private static readonly Dictionary<string, string> mapping = new Dictionary<string, string>() {
            { AttributeName.StudentID,"s.ID" },
            { AttributeName.CourseID, "c.ID"}
        };

        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            throw new NotImplementedException();
        }



        protected override SQLiteParameter[] BuildInsertParameters(params Args[] conditions)
        {
            return BuildParamsWithDate(conditions);
        }

        protected override SQLiteParameter[] BuildQueryParameters(params Args[] conditions)
        {
            return BuildDefaultParams(conditions).ToArray();
        }

        protected override string BuildQuerySql(params Args[] conditions)
        {
            if (conditions == null || conditions.Length == 0 || conditions[0] == null)
            {
                return selectAllSql;
            }


            StringBuilder builder = new StringBuilder(selectAllSql);
            builder.Append(" WHERE ");

            foreach (var item in conditions)
            {
                string name = item.Name;
                if (mapping.ContainsKey(name))
                {
                    name = mapping[name];
                }
                builder.Append(name);
                builder.Append(" ");
                builder.Append(item.Condition);
                builder.Append(" @");
                builder.Append(item.Name);
                builder.Append(" and ");
            }

            if (conditions != null && conditions.Length > 0)
            {
                builder.Remove(builder.Length - 5, 5);
            }

            return builder.ToString();
        }

        protected override string GetInsertSql()
        {
            return insertSql;
        }


        protected override string GetQuerySql()
        {
            return selectAllSql;
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
