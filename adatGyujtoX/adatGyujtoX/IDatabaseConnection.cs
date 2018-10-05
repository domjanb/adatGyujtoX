using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace adatGyujtoX
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
