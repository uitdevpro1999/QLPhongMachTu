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
        public int autogenerate_mahd()
        {
            int mahd = 1;
            string query = string.Empty;
            query += "SELECT MAX (KQ.MAHD) AS MM from (SELECT CONVERT(float, tblHOADON.maHD) AS MABN FROM tblHOADON ) AS KQ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                mahd = int.Parse(reader["MM"].ToString()) + 1;
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
            return mahd;
        }
        public float doanhthu(string ngHD)
        {
            float doanhthu = 0;
            string query = string.Empty;
            query += "SELECT sum (HD.tongTien) as doanhthu FROM tblHOADON HD WHERE HD.nglapHD=@ngHD";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@ngHD", ngHD);
     
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                doanhthu = float.Parse(reader["doanhthu"].ToString());

                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return doanhthu;
        }
        public int sobenhnhan(string ngHD)
        {
            int sobn = 0;
            string query = string.Empty;
            query += "SELECT count (HD.maHD) as sobn FROM tblHOADON HD WHERE HD.nglapHD=@ngHD";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@ngHD", ngHD);

                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sobn = int.Parse(reader["sobn"].ToString());

                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return sobn;
        }
        public List<HoadonDTO> selectByMonth(string month,string year)
        {
            string query = string.Empty;
            query += " SELECT nglapHD ";
            query += " FROM [tblHOADON]";
            query += " WHERE MONTH(nglapHD)=@month and YEAR(nglapHD)=@year group by nglapHD ";


            List<HoadonDTO> lsHoadon = new List<HoadonDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                HoadonDTO hd = new HoadonDTO();
                                hd.NgayHd = DateTime.Parse(reader["nglapHD"].ToString());
                                lsHoadon.Add(hd);

                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return lsHoadon;
        }
    }
}
