using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class AssistantService : Service
    {
        private static string selectAllSql = "select ID, name from assistant;";


        public override bool Add(SQLiteConnection conn, Model model)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(SQLiteConnection conn, object id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override string SelectAllSql()
        {
            return selectAllSql;
        }
    }
}
