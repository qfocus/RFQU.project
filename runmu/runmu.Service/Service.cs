using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Service
{
    public abstract class Service : IService
    {

        protected abstract string GetSql();


        public virtual DataTable GetAll(SQLiteConnection conn)
        {
            string sql = GetSql();

            DataTable result = new DataTable();

            SQLiteCommand command = new SQLiteCommand(sql, conn);

            SQLiteDataAdapter adp = new SQLiteDataAdapter(command);

            adp.Fill(result);

            return result;
        }


        public virtual DataTable GetAll()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                DataTable table = GetAll(conn);

                conn.Close();

                return table;
            }
        }


        public virtual bool Update<T>(T item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
