using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class TeacherService : Service
    {
        private static string selectAllSql = "SELECT ID, name as '姓名' ,qq as 'QQ', alias as '昵称',email FROM teacher";
        private static string updateSql = @"UPDATE teacher set name = @name, alias = @alias, qq = @qq, email = @email, 
                                            updateTime = @date WHERE ID = @id;";
        private static string insertSql = @"INSERT INTO `teacher`
                                           (`name`,`alias`,`qq`,`email`,`createdTime`,`updateTime`) VALUES 
                                           (@name, @alias, @qq, @email, @date, @date);";


        public override bool Update(SQLiteConnection conn, DataTable table)
        {

            DateTime now = DateTime.Now;
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Unchanged)
                {
                    continue;
                }

                int id = Convert.ToInt32(row[0]);
                string name = row[1].ToString();
                string qq = row[2].ToString();
                string alias = row[3].ToString();
                string date = now.ToString();
                string email = row[4].ToString();

                SQLiteCommand cmd = new SQLiteCommand(updateSql, conn);
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", Value = name, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@alias", Value = alias, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@qq", Value = qq, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@email", Value = email, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@date", Value = date, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@id", Value = id, DbType = DbType.Int32 });

                cmd.ExecuteNonQuery();

            }


            return true;
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
            throw new NotImplementedException();
        }
    }
}
