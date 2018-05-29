using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Service
{
    public class CourseService
    {
        public DataTable GetCourses()
        {
            DataTable table = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=runmu.db;Version=3;"))
            {
                conn.Open();
                string sql = "select * from course";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adp = new SQLiteDataAdapter(command);

                adp.Fill(table);

                conn.Close();
            }

            return table;



        }
    }
}
