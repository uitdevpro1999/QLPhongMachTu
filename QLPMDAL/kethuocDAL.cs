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
        public List<KethuocDTO> selectbypkb(string mapkb)
        {
            string query = string.Empty;
            query += "SELECT KT.maToa,KT.maThuoc,KT.soLuong FROM tblPKB PKB JOIN tblTOA T ON PKB.maPKB=T.maPKB JOIN tblKETHUOC KT ON T.maToa=KT.maToa JOIN tblTHUOC TH ON KT.maThuoc=TH.maThuoc WHERE PKB.maPKB=@mapkb";


            List<KethuocDTO> lskethuoc = new List<KethuocDTO>();

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
                                KethuocDTO kt = new KethuocDTO();
                                kt.SoLuong= int.Parse(reader["soLuong"].ToString());
                                kt.MaToa= reader["maToa"].ToString();
                                kt.MaThuoc = reader["maThuoc"].ToString();
                                lskethuoc.Add(kt);

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
            return lskethuoc;
        }
        public List<KethuocDTO> baocaobymonth(string month,string year)
        {
            string query = string.Empty;
            query += "SELECT TH.maThuoc, TH.tenThuoc, sum (KT.soLuong) as soLuong FROM tblTOA T JOIN tblKETHUOC KT ON T.maToa=KT.maToa JOIN tblTHUOC TH ON KT.maThuoc=TH.maThuoc WHERE MONTH(T.ngKeToa)=@month and year(T.ngKeToa)=@year group by TH.maThuoc,TH.tenThuoc";


            List<KethuocDTO> lskethuoc = new List<KethuocDTO>();

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
                                KethuocDTO kt = new KethuocDTO();
                                kt.SoLuong = int.Parse(reader["soLuong"].ToString());
                                kt.MaThuoc = reader["maThuoc"].ToString();
                                lskethuoc.Add(kt);

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
            return lskethuoc;
        }
        public int solandungbymonth(string mathuoc, string month, string year)
        {
            int SLD = 0;
            string query = string.Empty;
            query += "SELECT  count (KT.maToa) as SLD FROM tblTOA T JOIN tblKETHUOC KT ON T.maToa=KT.maToa JOIN tblTHUOC TH ON KT.maThuoc=TH.maThuoc WHERE MONTH(T.ngKeToa)=@month and year(T.ngKeToa)=@year and TH.maThuoc=@mathuoc";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@mathuoc", mathuoc);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                SLD = int.Parse(reader["SLD"].ToString());
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
            return SLD;
        }

    }
}
