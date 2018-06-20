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
        private static string insertSql = @"INSERT INTO `platform` 
                                           (`name`,`createdTime`,`lastModifiedTime`) VALUES
                                           (@name, @date, @date);";
        private static string updateSql = @"UPDATE `platform` SET name = @name, lastModifiedTime = @date WHERE ID = @id";


        public override DataTable Query(SQLiteConnection conn, object id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            string date = DateTime.Now.ToString();
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                SQLiteCommand cmd = new SQLiteCommand(updateSql, conn);
                int id = Convert.ToInt32(row[0]);
                string name = row[1].ToString();
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@id", Value = id, DbType = DbType.Int32 });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", Value = name, DbType = DbType.String });
                cmd.Parameters.Add(new SQLiteParameter() { ParameterName = "@date", Value = date, DbType = DbType.String });

                cmd.ExecuteNonQuery();

            }
            return true;
        }

        protected override SQLiteParameter[] BuildInsertParameters(Dictionary<string, object> values)
        {
            return BuildDefaultParams(values);
        }

        protected override string InsertSql()
        {
            return insertSql;
        }

        protected override string SelectAllSql()
        {
            return getAllSql;
        }
    }
}
