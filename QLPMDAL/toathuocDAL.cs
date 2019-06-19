using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLPMDTO;
using System.Configuration;

namespace QLPMDAL
{
    public class ToathuocDAL
    {
        private string connectionString;

        public ToathuocDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool them(ToathuocDTO tt)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblTOA] ([maToa], [maPKB], [ngKeToa])";
            query += "VALUES (@maToa,@maPKB,@ngKeToa)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maToa", tt.MaToa);
                    cmd.Parameters.AddWithValue("@maPKB", tt.MaPkb);
                    cmd.Parameters.AddWithValue("@ngKeToa", tt.NgayKetoa);
                    
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
