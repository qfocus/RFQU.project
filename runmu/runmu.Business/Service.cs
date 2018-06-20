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
        protected abstract string InsertSql();
        protected abstract SQLiteParameter[] BuildInsertParameters(Dictionary<string, object> values);
        public abstract bool Update(SQLiteConnection conn, DataTable table);

        public abstract DataTable Query(SQLiteConnection conn, object id);


        public virtual void Add(SQLiteConnection conn, Dictionary<string, object> values)
        {
            string sql = InsertSql();
            SQLiteParameter[] parameters = BuildInsertParameters(values);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

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

        protected virtual SQLiteParameter[] BuildDefaultParams(Dictionary<string, object> values)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.Add(new SQLiteParameter("@date", DateTime.Now.ToString()));
            foreach (var item in values)
            {
                list.Add(new SQLiteParameter()
                {
                    ParameterName = "@" + item.Key,
                    Value = item.Value,
                });
            }

            return list.ToArray();
        }
    }
}
