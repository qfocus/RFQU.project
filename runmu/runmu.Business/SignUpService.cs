using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class SignUpService : Service
    {
        public override DataTable Query(SQLiteConnection conn, object id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override SQLiteParameter[] BuildInsertParameters(Dictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        protected override string InsertSql()
        {
            throw new NotImplementedException();
        }

        protected override string SelectAllSql()
        {
            throw new NotImplementedException();
        }
    }
}
