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
        public static void ImportFullPaymentStudents(IService service, SQLiteConnection conn, string path)
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
                paras.Add(PropertyName.NAME, name);
                paras.Add(PropertyName.QQ, qq);

                service.Add(conn, paras);
                paras.Clear();
            }
        }
    }
}
