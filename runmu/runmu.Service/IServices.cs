using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Service
{
    public interface IService
    {
        DataTable GetAll();
        DataTable GetAll(SQLiteConnection conn);
        bool Update<T>(T item);
        bool Delete(List<int> ids);
    }
}
