using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Service
{
    public class CourseService : IService
    {
        private static string sql = "select id, name as '姓名' ,qq as 'QQ', alias as '昵称',email from teacher";


        public DataTable GetAll()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                DataTable table = GetAll(conn);

                conn.Close();

                return table;
            }
        }

        public DataTable GetAll(SQLiteConnection conn)
        {
            DataTable result = new DataTable();

            SQLiteCommand command = new SQLiteCommand(sql, conn);

            SQLiteDataAdapter adp = new SQLiteDataAdapter(command);

            adp.Fill(result);

            return result;
        }

        public bool Update<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
