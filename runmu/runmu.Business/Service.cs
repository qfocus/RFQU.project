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

        protected abstract string GetSelectAllSql();
        protected abstract string GetInsertSql();
        protected abstract string GetQuerySql();
        protected abstract string TableName();
        protected abstract SQLiteParameter[] BuildInsertParameters(Dictionary<string, object> values);
        protected abstract SQLiteParameter[] BuildQueryParameters(Dictionary<string, object> values);
        public abstract bool Update(SQLiteConnection conn, DataTable table);


        public virtual void Add(SQLiteConnection conn, Dictionary<string, object> values)
        {
            string sql = GetInsertSql();
            SQLiteParameter[] parameters = BuildInsertParameters(values);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        public virtual DataTable GetAll(SQLiteConnection conn)
        {
            string sql = GetSelectAllSql();

            DataTable result = new DataTable();

            SQLiteCommand command = new SQLiteCommand(sql, conn);

            SQLiteDataAdapter adp = new SQLiteDataAdapter(command);

            adp.Fill(result);

            return result;
        }
        public Dictionary<int, string> GetNames(SQLiteConnection conn)
        {
            DataTable table = GetAll(conn);

            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row[0]);
                string name = row[1].ToString();
                result.Add(id, name);
            }
            return result;
        }

        public virtual DataTable Query(SQLiteConnection conn, Dictionary<string, object> values)
        {
            string sql = QuerySql(values);
            SQLiteParameter[] parameters = BuildQueryParameters(values);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);

            SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

            DataTable result = new DataTable();
            adp.Fill(result);

            return result;
        }

        public virtual DataTable MutiplyQuery(SQLiteConnection conn, Dictionary<string, object> values)
        {
            return new DataTable();
        }


        public bool Delete(SQLiteConnection conn, List<int> ids)
        {
            throw new NotImplementedException();
        }

        protected virtual SQLiteParameter[] BuildDefaultOperateParams(Dictionary<string, object> values)
        {
            List<SQLiteParameter> list = BuildDefaultParams(values);
            list.Add(new SQLiteParameter("@date", DateTime.Now.ToString()));

            return list.ToArray();
        }

        protected List<SQLiteParameter> BuildDefaultParams(Dictionary<string, object> values)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            foreach (var item in values)
            {
                list.Add(new SQLiteParameter()
                {
                    ParameterName = "@" + item.Key,
                    Value = item.Value,
                });
            }
            return list;

        }



        protected virtual string QuerySql(Dictionary<string, object> values)
        {
            StringBuilder builder = new StringBuilder(GetQuerySql());

            foreach (var item in values)
            {
                builder.Append(item.Key);
                builder.Append(" = @");
                builder.Append(item.Key);
                builder.Append(" and ");
            }

            builder.Remove(builder.Length - 5, 5);


            return builder.ToString();
        }

        protected virtual string BuildUpdateSql(List<string> attributes, List<string> conditions)
        {
            StringBuilder builder = new StringBuilder("UPDATE ");
            builder.Append(TableName());
            builder.Append(" SET ");
            foreach (string item in attributes)
            {          
                builder.Append(item);
                builder.Append(" = @");
                builder.Append(item);
                builder.Append(" , ");
            }

            builder.Append(" updateTime = @date ");

            builder.Append(" WHERE ");

            foreach (string item in conditions)
            {
                builder.Append(item);
                builder.Append(" = @");
                builder.Append(item);
                builder.Append(" and ");
            }

            builder.Remove(builder.Length - 5, 5);


            return builder.ToString();
        }

        public bool Update(SQLiteConnection conn, List<string> attributes, List<string> conditions, Dictionary<string, object> values)
        {
            string sql = BuildUpdateSql(attributes, conditions);
            SQLiteParameter[] args = BuildDefaultOperateParams(values);

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddRange(args);
            cmd.ExecuteNonQuery();


            return true;
        }
    }
}
