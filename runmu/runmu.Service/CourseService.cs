using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class CourseService : Service
    {
        private static string selectSql = @"select c.ID, c.teacherID, c.name as '课程', c.price as '价格', t.name as '教师' from course as c join teacher as t on c.teacherId =  t.id";
        private static string insertSql = @"INSERT INTO `course`
                                           (`teacherID`,`name`,`price`,`createdTime`,`lastModifiedTime`) VALUES 
                                           (@teacherID, @name, @price, @date, @date);";

        public override bool Add(Model model)
        {
            string date = DateTime.Now.ToString();
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                DateTime now = DateTime.Now;
                SQLiteCommand cmd = new SQLiteCommand(insertSql, conn);
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@teacherID", Value = model.TeacherId, DbType = DbType.Int32 });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", Value = model.Name, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@price", Value = model.Price, DbType = DbType.Double });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@date", Value = date, DbType = DbType.String });

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }

        public override bool Update(DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override string SelectAllSql()
        {
            return selectSql;
        }
    }
}
