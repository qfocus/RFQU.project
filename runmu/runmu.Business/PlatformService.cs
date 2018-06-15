using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runmu.Business
{
    public class PlatformService : Service
    {
        private static string getAllSql = "SELECT ID, name AS '平台' FROM platform;";

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
            return getAllSql;
        }
    }
}
