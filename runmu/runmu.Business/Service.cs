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
        protected abstract SQLiteParameter[] BuildInsertParameters(params Args[] values);
        protected abstract SQLiteParameter[] BuildQueryParameters(params Args[] values);
        public abstract bool Update(SQLiteConnection conn, DataTable table);


        public virtual void Add(SQLiteConnection conn, params Args[] values)
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

        public virtual DataTable Query(SQLiteConnection conn, params Args[] values)
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

        protected virtual SQLiteParameter[] BuildDefaultOperateParams(params Args[] values)
        {
            List<SQLiteParameter> list = BuildDefaultParams(values);
            list.Add(new SQLiteParameter("@date", DateTime.Now.ToString()));

            return list.ToArray();
        }


        protected List<SQLiteParameter> BuildDefaultParams(params Args[] values)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            foreach (var item in values)
            {
                list.Add(new SQLiteParameter()
                {
                    ParameterName = "@" + item.Name,
                    Value = item.Value,
                });
            }
            return list;

        }

        protected virtual string QuerySql(params Args[] values)
        {
            StringBuilder builder = new StringBuilder(GetQuerySql());

            foreach (var item in values)
            {
                builder.Append(item.Name);
                builder.Append(" ");
                builder.Append(item.Condition);
                builder.Append(" @");
                builder.Append(item.Name);
                builder.Append(" and ");
            }

            builder.Remove(builder.Length - 5, 5);


            return builder.ToString();
        }

        protected virtual string BuildUpdateSql(List<Args> attributes, params Args[] conditions)
        {
            StringBuilder builder = new StringBuilder("UPDATE ");
            builder.Append(TableName());
            builder.Append(" SET ");
            foreach (var item in attributes)
            {
                builder.Append(item.Name);
                builder.Append(" = @");
                builder.Append(item.Name);
                builder.Append(" , ");
            }

            builder.Append(" updateTime = @date ");

            builder.Append(" WHERE ");

            foreach (var item in conditions)
            {
                builder.Append(item.Name);
                builder.Append(" = @");
                builder.Append(item.Name);
                builder.Append(" and ");
            }
            builder.Remove(builder.Length - 5, 5);


            return builder.ToString();
        }

        public bool Update(SQLiteConnection conn, List<Args> attributes, params Args[] conditions)
        {
            string sql = BuildUpdateSql(attributes, conditions);
            //SQLiteParameter[] args = BuildDefaultOperateParams(attributes.ToArray());
            List<SQLiteParameter> args = BuildDefaultParams(attributes.ToArray());
            args.AddRange(BuildDefaultParams(conditions.ToArray()));
            args.Add(new SQLiteParameter("@date", DateTime.Now.ToString()));



            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddRange(args.ToArray());
            cmd.ExecuteNonQuery();


            return true;
        }
    }
}
