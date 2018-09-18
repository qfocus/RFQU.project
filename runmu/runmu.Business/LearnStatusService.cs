using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runmu.Business
{
    public class LearnStatusService : Service
    {
        private static string insertSql = "";
        private static string selectAllSql = "SELECT ID, name, alias from learnStatus";



        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }


        protected override string GetQuerySql()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectAllSql()
        {
            return selectAllSql;
        }

        protected override string TableName()
        {
            throw new NotImplementedException();
        }
    }
}
