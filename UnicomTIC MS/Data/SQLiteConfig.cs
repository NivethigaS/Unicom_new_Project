using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.Data
{
    public static class SQLiteConfig
    {
        private static string connectionString = "Data Source = UnicomManageDB.db; Version =3;";

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;

        }
    }
}
