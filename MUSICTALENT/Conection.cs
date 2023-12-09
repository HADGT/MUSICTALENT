using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSICTALENT
{
    internal class Conection
    {
        string constr = @"Data Source=DUONGHA\DUONGHA;Initial Catalog=MUSICTALENT;Integrated Security=True";
        SqlConnection conn;
        public Conection()
        {
            conn = new SqlConnection(constr);
        }
        public DataSet Laydulieu(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool Thucthi(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch
            { return false; }
        }
    }
}
