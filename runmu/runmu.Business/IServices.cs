using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public interface IService
    {

        DataTable GetAll(SQLiteConnection conn);
        Dictionary<int, string> GetNames(SQLiteConnection conn);
        DataTable Query(SQLiteConnection conn, params Args[] values);
        DataTable MutiplyQuery(SQLiteConnection conn, Dictionary<string, object> values);
        bool Update(SQLiteConnection conn, DataTable item);
        bool Update(SQLiteConnection conn, List<Args> attributes, params Args[] conditions);
        bool Delete(SQLiteConnection conn, List<int> ids);
        void Add(SQLiteConnection conn, params Args[] values);
    }
}
