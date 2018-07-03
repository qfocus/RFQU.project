using CsvHelper;
using runmu.Business;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace runmu
{
    public sealed class Importer
    {
        private Dictionary<long, int> qqMapping;
        private Dictionary<string, int> teacherMapping;
        private Dictionary<string, int> courseMaping;

        public Importer()
        {
            this.qqMapping = new Dictionary<long, int>();
        }


        public void ImportFullPaymentStudents(IService service, SQLiteConnection conn, string path)
        {
            List<string> list = new List<string>();

            TextReader textReader = File.OpenText(path);
            Dictionary<string, object> paras = new Dictionary<string, object>();
            CsvReader reader = new CsvReader(textReader);
            reader.Read();

            while (reader.Read())
            {
                string name = reader[4];
                string qq = reader[3];
                if (list.Contains(qq))
                {
                    continue;
                }
                list.Add(qq);
                paras.Add(AttributeName.NAME, name);
                paras.Add(AttributeName.QQ, qq);
                paras.Add(AttributeName.Phone, 100000);
                paras.Add(AttributeName.Wechat, "");
                paras.Add(AttributeName.Email, "");
                service.Add(conn, paras);
                paras.Clear();
            }
        }
    }
}
