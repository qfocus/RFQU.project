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
        DataTable GetAll();
        DataTable GetAll(SQLiteConnection conn);
        bool Update(DataTable item);
        bool Delete(List<int> ids);
        bool Add(Model model);
    }
}
