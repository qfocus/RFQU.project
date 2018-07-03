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
            (`courseID`,`studentID`,`payType`,`values`,`status`,`payDate`,`endDate`, updateTime,createdTime)
            values
            (@courseID, @studentID, @payType, @values, @status, @payDate, @endDate, @date, @date)";

        private static string selectAllSql =
            @"select p.ID, s.ID, c.name as '课程',s.name as '学员', p.payType as '类型' , p.`values` as '金额', p.status as '状态',p.payDate as '日期' from payment as p
            join course as c on p.courseID = c.ID
            join students as s on p.studentID = s.ID";


        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            throw new NotImplementedException();
        }


        public override DataTable Query(SQLiteConnection conn, Dictionary<string, object> values)
        {
            StringBuilder builder = new StringBuilder(selectAllSql);
            List<String> querys = new List<string>();

            foreach (var item in values)
            {
                if (item.Key == AttributeName.StudentID)
                {
                    querys.Add(" s.ID = @studentID ");
                }
                if (item.Key == AttributeName.CourseID)
                {
                    querys.Add(" c.ID = @courseID ");
                }
            }

            for (int i = 0; i < querys.Count; i++)
            {
                if (i == 0)
                {
                    builder.Append(" WHERE ");
                }
                builder.Append(querys[i]);
                builder.Append(" and ");
            }

            if (querys.Count > 0)
            {
                builder.Remove(builder.Length - 5, 5);
            }



            List<SQLiteParameter> paras = BuildDefaultParams(values);

            SQLiteCommand cmd = new SQLiteCommand(builder.ToString(), conn);
            cmd.Parameters.AddRange(paras.ToArray());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            DataTable result = new DataTable();
            adapter.Fill(result);

            return result;

        }

        protected override SQLiteParameter[] BuildInsertParameters(Dictionary<string, object> values)
        {
            return BuildDefaultOperateParams(values);
        }

        protected override SQLiteParameter[] BuildQueryParameters(Dictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertSql()
        {
            return insertSql;
        }

        protected override string QuerySql(Dictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        protected override string GetQuerySql()
        {
            throw new NotImplementedException();
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
