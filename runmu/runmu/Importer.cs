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
        public static void ImportStudents(IService service, SQLiteConnection conn, string path)
        {
            List<string> list = new List<string>();
            List<string> duplicate = new List<string>();

            TextReader textReader = File.OpenText(path);

            CsvReader reader = new CsvReader(textReader);
            reader.Read();

            while (reader.Read())
            {
                string name = reader[0];
                string qq = reader[1];
                if (list.Contains(qq))
                {
                    duplicate.Add(qq + ":" + name);
                    continue;
                }
                list.Add(qq);
                Model model = new Model
                {
                    Qq = qq,
                    Name = name
                };
                service.Add(conn, model);
            }
            Logger.Warnning(duplicate);
        }
    }
}
