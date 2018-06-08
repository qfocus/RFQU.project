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
        private static string selectAllSql = "select ID,name as '姓名',qq as 'QQ',wechat as '微信', phone as '电话',email from students;";
        private static string insertSql = @"INSERT INTO `students`
                                         (`name`,`qq`,`email`,`phone`,`weChat`,`createdTime`,`lastModifiedTime`) VALUES
                                         (@name, @qq, @email, @phone, @weChat, @date, @date);";
        private static string updateSql = @"UPDATE students set name = @name, email = @email, phone = @phone,
                                            lastModifiedTime = @date WHERE ID = @id;";

        public override bool Add(Model model)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                DateTime now = DateTime.Now;
                SQLiteCommand cmd = new SQLiteCommand(insertSql, conn);
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", Value = model.Name, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@email", Value = model.Email, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@phone", Value = model.Phone, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@qq", Value = model.Qq, DbType = DbType.Int64 });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@weChat", Value = model.WeChat, DbType = DbType.String });
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
                string date = now.ToString();
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Unchanged)
                    {
                        continue;
                    }

                    int id = Convert.ToInt32(row[0]);
                    string name = row[1].ToString();
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
