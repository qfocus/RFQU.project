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
        private static string tableName = "`course`";
        private static string selectSql = @"SELECT c.ID, c.name as '课程', c.teacherID,  c.price as '价格', t.name as '教师' from course as c join teacher as t on c.teacherId =  t.id";
        private static string insertSql = @"INSERT INTO `course`
                                           (`teacherID`,`name`,`price`,`createdTime`,`updateTime`) VALUES 
                                           (@teacherID, @name, @price, @date, @date);";
        private static string updateSql = @"UPDATE course set name = @name, price = @price, 
                                            updateTime = @date WHERE ID = @id;";

    


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
                double price = Convert.ToDouble(row[3]);
                SQLiteCommand cmd = new SQLiteCommand(updateSql, conn);
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@id", Value = id, DbType = DbType.Int32 });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", Value = name, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@price", Value = price, DbType = DbType.Double });
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
            throw new NotImplementedException();
        }

        protected override string GetInsertSql()
        {
            return insertSql;
        }



        protected override string GetQuerySql()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectAllSql()
        {
            return selectSql;
        }

        protected override string TableName()
        {
            return tableName;
        }
    }
}
