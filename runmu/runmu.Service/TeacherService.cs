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
                                            lastModifiedTime = @date WHERE ID = @id;";
        private static string insertSql = @"INSERT INTO `teacher`
                                           (`name`,`alias`,`qq`,`email`,`createdTime`,`lastModifiedTime`) VALUES 
                                           (@name, @alias, @qq, @email, @date, @date);";

        public override bool Add(Model model)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                DateTime now = DateTime.Now;
                SQLiteCommand cmd = new SQLiteCommand(insertSql, conn);
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", Value = model.Name, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@alias", Value = model.Alias, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@qq", Value = model.Qq, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@email", Value = model.Email, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@date", Value = now.ToString(), DbType = DbType.String });
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }

        public override bool Update(DataTable table)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
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
                conn.Close();
            }

            return true;
        }

        protected override string SelectAllSql()
        {
            return selectAllSql;
        }
    }
}
