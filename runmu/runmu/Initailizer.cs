using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using runmu.Business;

namespace runmu
{
    public sealed class Initailizer
    {
        public static void InitEnvironment()
        {
            if (!Directory.Exists("backup"))
            {
                Directory.CreateDirectory("backup");
            }
        }

        public static void Init()
        {
            InitEnvironment();

           // InitDataBase();

        }

        public static void Backup()
        {
            File.Move("runmu.db", "backup//runmu.db_b" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
        }


        public static bool InitDataBase()
        {
            if (File.Exists("runmu.db"))
            {
                return true;
            }

            SQLiteConnection.CreateFile("runmu.db");
            string sql = File.ReadAllText("init.sql");

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                SQLiteTransaction transaction = conn.BeginTransaction();
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    transaction.Rollback();
                    return false;
                }
                finally { transaction.Dispose(); }
            }
        }


        

    }
}
