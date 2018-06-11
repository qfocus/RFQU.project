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
        DataTable Query(SQLiteConnection conn, object id);
        bool Update(SQLiteConnection conn, DataTable item);
        bool Delete(SQLiteConnection conn, List<int> ids);
        bool Add(SQLiteConnection conn, Model model);
    }
}
