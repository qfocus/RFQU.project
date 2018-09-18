using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class StudentsService : Service
    {
        private static string selectAllSql = @"select ID,ID as 'QQ', name as '姓名',wechat as '微信', phone as '电话',email from students ";
        private static string insertSql = @"INSERT INTO `students`
                                         (`id`,`name`,`email`,`phone`,`weChat`,`createdTime`,`updateTime`) VALUES
                                         (@ID, @name, @email, @phone, @weChat, @date, @date);";
        private static string updateSql = @"UPDATE students set name = @name, email = @email, phone = @phone, wechat = @wechat,
                                            updateTime = @date WHERE ID = @id;";

    

        public override bool Update(SQLiteConnection conn, DataTable table)
        {

            DateTime now = DateTime.Now;
            string date = now.ToString();
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Unchanged)
                {
                    continue;
                }

                int id = Convert.ToInt32(row[0]);
                string name = row[2].ToString();
                object wechat = row[3];
                object phone = row[4];
                object email = row[5];


                SQLiteCommand cmd = new SQLiteCommand(updateSql, conn);
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@id", Value = id, DbType = DbType.Int32 });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", Value = name, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@email", Value = email, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@phone", Value = phone, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@weChat", Value = wechat, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@date", Value = now.ToString(), DbType = DbType.String });

                cmd.ExecuteNonQuery();

            }


            return true;
        }

        protected override SQLiteParameter[] BuildInsertParameters(params Args[] values)
        {
            return BuildParamsWithDate(values);
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
            return selectAllSql;
        }

        protected override string GetSelectAllSql()
        {
            return selectAllSql;
        }

        protected override string TableName()
        {
            throw new NotImplementedException();
        }
    }
}
