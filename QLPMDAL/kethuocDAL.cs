using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLPMDTO;
using System.Configuration;

namespace QLPMDAL
{
    public class KethuocDAL
    {
        private string connectionString;

        public KethuocDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        
        public bool kethuoc(KethuocDTO kt)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblKETHUOC] ([maToa], [maThuoc],[soLuong])";
            query += "VALUES (@maToa,@maThuoc,@soLuong)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maToa", kt.MaToa);
                    cmd.Parameters.AddWithValue("@maThuoc", kt.MaThuoc);
                    cmd.Parameters.AddWithValue("@soLuong", kt.SoLuong);

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
