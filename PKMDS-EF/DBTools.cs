using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace PKMDS
{
    public static class DBTools
    {
        private static DbConnection con;
        public static void OpenDB(string DBFile = @"veekun-pokedex.sqlite")
        {
            if (con != null) return;
            try
            {
                var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=true;", DBFile);
                using (var factory = new System.Data.SQLite.SQLiteFactory())
                    con = factory.CreateConnection();
                con.ConnectionString = connString;
                con.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error opening database: {0}", ex.Message);
            }
        }

        public static void CloseDB()
        {
            try
            {
                if (con == null) return;
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error closing database: {0}", ex.Message);
            }
        }

        public static DataTable GetData(DbCommand Sql)
        {
            DataTable table = new DataTable();
            try
            {
                using (DbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = Sql.CommandText;
                    foreach (var param in Sql.Parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                    table.Load(cmd.ExecuteReader());
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return table;
        }


    }
}
