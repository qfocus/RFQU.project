using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public abstract class Service : IService
    {

        protected abstract string SelectAllSql();
        public abstract bool Update(SQLiteConnection conn, DataTable table);
        public abstract bool Add(SQLiteConnection conn, Model model);
        public abstract DataTable Query(SQLiteConnection conn, object id);

        public virtual DataTable GetAll(SQLiteConnection conn)
        {
            string sql = SelectAllSql();

            DataTable result = new DataTable();

            SQLiteCommand command = new SQLiteCommand(sql, conn);

            SQLiteDataAdapter adp = new SQLiteDataAdapter(command);

            adp.Fill(result);

            return result;
        }

        public bool Delete(SQLiteConnection conn, List<int> ids)
        {
            throw new NotImplementedException();
        }

    }
}
