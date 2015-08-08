using PKMDS;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PKMDS_EF_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable results;
            DBTools.OpenDB();
            //using (DbCommand cmd = new SqlCommand("SELECT * FROM pokemon LIMIT 1"))
            //{
            //    results = DBTools.GetData(cmd);
            //}

            Box box = new Box();

            for (int i = 0; i < box.Pokemon.Count; i++)
            {
                box[i] = (new Pokemon() { });
            }

            DBTools.CloseDB();
        }
    }
}
