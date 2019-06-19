using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPMDTO;
using System.Configuration;
using System.Data.SqlClient;
namespace QLPMDAL
{
    public class HoadonDAL
    {
        private string connectionString;

        public HoadonDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool them(HoadonDTO hd)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblHOADON] ([maHD], [nglapHD], [maPKB],[tongTien]) ";
            query += "VALUES (@maHD,@nglapHD,@maPKB,@tongTien)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maHD", hd.MaHd);
                    cmd.Parameters.AddWithValue("@nglapHD", hd.NgayHd);
                    cmd.Parameters.AddWithValue("@maPKB", hd.MaPkb);
                    cmd.Parameters.AddWithValue("@tongTien", hd.TongTien);
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
        public float tienthuoc(HoadonDTO hd,string mapkb)
        {
            float tien = 0;
            string query = string.Empty;
            query += "SELECT SUM(TH.Dongia*KT.soLuong) AS TIENTHUOC";
            query += " FROM tblPKB PKB JOIN tblTOA T ON PKB.maPKB=T.maPKB JOIN tblKETHUOC KT ON T.maToa=KT.maToa JOIN tblTHUOC TH ON KT.maThuoc=TH.maThuoc WHERE PKB.maPKB=@mapkb";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mapkb", mapkb);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                tien = float.Parse(reader["TIENTHUOC"].ToString());
                            }
                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        
                    }
                }
            }
            return tien;
        }
    }
}
