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
        protected abstract SQLiteParameter[] BuildInsertParameters(params Args[] conditions);
        protected abstract SQLiteParameter[] BuildQueryParameters(params Args[] conditions);
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

        public virtual DataTable Query(SQLiteConnection conn, params Args[] conditions)
        {
            string sql = BuildQuerySql(conditions);
            SQLiteParameter[] parameters = BuildQueryParameters(conditions);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);

            SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

            DataTable result = new DataTable();
            adp.Fill(result);

            return result;
        }

        public virtual DataTable MutiplyQuery(SQLiteConnection conn, params Args[] values)
        {
            return new DataTable();
        }


        public bool Delete(SQLiteConnection conn, List<int> ids)
        {
            throw new NotImplementedException();
        }

        protected virtual SQLiteParameter[] BuildParamsWithDate(params Args[] conditions)
        {
            List<SQLiteParameter> list = BuildDefaultParams(conditions);
            list.Add(new SQLiteParameter("@date", DateTime.Now.ToString()));

            return list.ToArray();
        }


        protected List<SQLiteParameter> BuildDefaultParams(params Args[] conditions)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            if (conditions == null || conditions.Length == 0 || conditions[0] == null)
            {
                return list;
            }


            foreach (var item in conditions)
            {
                list.Add(new SQLiteParameter()
                {
                    ParameterName = "@" + item.Name,
                    Value = item.Value,
                });
            }
            return list;

        }

        protected virtual string BuildQuerySql(params Args[] conditions)
        {
            StringBuilder builder = new StringBuilder(GetQuerySql());

            if (conditions == null || conditions.Length == 0 || conditions[0] == null)
            {
                return builder.ToString();
            }

            builder.Append(" WHERE ");
            foreach (var item in conditions)
            {
                string name = item.Name;
                if (name == AttributeName.Status)
                {
                    name = "statusID";
                }
                builder.Append(name);
                builder.Append(" ");
                builder.Append(item.Condition);
                builder.Append(" @");
                builder.Append(item.Name);
                builder.Append(" and ");
            }

            if (conditions != null && conditions.Length > 0)
            {
                builder.Remove(builder.Length - 5, 5);
            }

            return builder.ToString();
        }

        protected virtual string BuildUpdateSql(List<Args> attributes, params Args[] conditions)
        {
            StringBuilder builder = new StringBuilder("UPDATE ");
            builder.Append(TableName());
            builder.Append(" SET ");
            foreach (var item in attributes)
            {
                string name = item.Name;


                builder.Append(name);
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
