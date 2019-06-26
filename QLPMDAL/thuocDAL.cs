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
    public class ThuocDAL
    {
        private string connectionString;

        public ThuocDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool them(ThuocDTO th)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblTHUOC] ([maThuoc], [tenThuoc], [DVT],[Dongia],[CachDung])";
            query += "VALUES (@maThuoc,@tenThuoc,@DVT,@Dongia,@CachDung)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maThuoc", th.MaThuoc);
                    cmd.Parameters.AddWithValue("@tenThuoc", th.TenThuoc);
                    cmd.Parameters.AddWithValue("@DVT", th.DVT);
                    cmd.Parameters.AddWithValue("@Dongia", th.DonGia);
                    cmd.Parameters.AddWithValue("@CachDung", th.CachDung);
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
        public bool sua(ThuocDTO th, string maThuocold)
        {
            string query = string.Empty;
            query += "update [tblTHUOC]";
            query += "set maThuoc=@maThuoc,tenThuoc=@tenThuoc,DVT=@DVT,Dongia=@Dongia,CachDung=@CachDung where maThuoc=@maThuocold";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maThuoc", th.MaThuoc);
                    cmd.Parameters.AddWithValue("@tenThuoc", th.TenThuoc);
                    cmd.Parameters.AddWithValue("@DVT", th.DVT);
                    cmd.Parameters.AddWithValue("@Dongia", th.DonGia);
                    cmd.Parameters.AddWithValue("@CachDung", th.CachDung);
                    cmd.Parameters.AddWithValue("@maThuocold", maThuocold);
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

                return true;
            }

        }
        public bool xoa(ThuocDTO th)
        {
            string query = string.Empty;
            query += "delete from [tblThuoc]";
            query += "where maThuoc=@maThuoc";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maThuoc", th.MaThuoc);
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

                return true;
            }
        }
        public List<ThuocDTO> select()
        {
            string query = string.Empty;
            query += "SELECT * ";
            query += "FROM [tblThuoc]";

            List<ThuocDTO> lsThuoc = new List<ThuocDTO>();

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
                                ThuocDTO th = new ThuocDTO();
                                th.MaThuoc = reader["maThuoc"].ToString();
                                th.TenThuoc = reader["tenThuoc"].ToString();
                                th.DVT = reader["DVT"].ToString();
                                th.CachDung = reader["CachDung"].ToString();
                                th.DonGia = float.Parse(reader["Dongia"].ToString());
                                
                                lsThuoc.Add(th);

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
            return lsThuoc;
        }
        public List<ThuocDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT * ";
            query += " FROM [tblTHUOC]";
            query += " WHERE ([maThuoc] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenThuoc] LIKE CONCAT('%',@sKeyword,'%'))";

            List<ThuocDTO> lsThuoc = new List<ThuocDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                ThuocDTO th = new ThuocDTO();
                                th.MaThuoc = reader["maThuoc"].ToString();
                                th.TenThuoc = reader["tenThuoc"].ToString();
                                th.DVT = reader["DVT"].ToString();
                                th.CachDung = reader["CachDung"].ToString();
                                th.DonGia = float.Parse(reader["Dongia"].ToString());

                                lsThuoc.Add(th);

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
            return lsThuoc;
        }
        public int autogenerate_mathuoc()
        {
            int mathuoc = 1;
            string query = string.Empty;
            query += "SELECT MAX (KQ.MATHUOC) AS MM from (SELECT CONVERT(float, tblTHUOC.maThuoc) AS MATHUOC FROM tblTHUOC ) AS KQ";

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
                                mathuoc = int.Parse(reader["MM"].ToString()) + 1;
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
            return mathuoc;
        }
        public List<ThuocDTO> selectbypkb(string mapkb)
        {
            string query = string.Empty;
            query += "SELECT TH.maThuoc,TH.tenThuoc,TH.CachDung,TH.DVT,TH.Dongia FROM tblPKB PKB JOIN tblTOA T ON PKB.maPKB=T.maPKB JOIN tblKETHUOC KT ON T.maToa=KT.maToa JOIN tblTHUOC TH ON KT.maThuoc=TH.maThuoc WHERE PKB.maPKB=@mapkb";


            List<ThuocDTO> lsThuoc = new List<ThuocDTO>();

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
                                ThuocDTO th = new ThuocDTO();
                                th.MaThuoc = reader["maThuoc"].ToString();
                                th.TenThuoc = reader["tenThuoc"].ToString();
                                th.DVT = reader["DVT"].ToString();
                                th.CachDung = reader["CachDung"].ToString();
                                th.DonGia = float.Parse(reader["Dongia"].ToString());

                                lsThuoc.Add(th);

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
            return lsThuoc;
        }
        public List<ThuocDTO> baocaobymonth(string month,string year)
        {
            string query = string.Empty;
            query += "SELECT TH.maThuoc, TH.tenThuoc, TH.DVT FROM tblTOA T JOIN tblKETHUOC KT ON T.maToa=KT.maToa JOIN tblTHUOC TH ON KT.maThuoc=TH.maThuoc WHERE MONTH(T.ngKeToa)=@month and YEAR(T.ngKeToa)=@year group by TH.maThuoc,TH.tenThuoc,TH.DVT";


            List<ThuocDTO> lsThuoc = new List<ThuocDTO>();

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
                                ThuocDTO th = new ThuocDTO();
                                th.MaThuoc = reader["maThuoc"].ToString();
                                th.TenThuoc = reader["tenThuoc"].ToString();              
                                th.DVT= reader["DVT"].ToString();
                                lsThuoc.Add(th);

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
            return lsThuoc;
        }
        public List<Donvi> getdonvi()
        {
            string query = string.Empty;
            query += "SELECT * FROM tblDONVI";


            List<Donvi> lsdv = new List<Donvi>();

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
                                Donvi dv = new Donvi();
                                dv.DonVi = reader["donVi"].ToString();
                                lsdv.Add(dv);

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
            return lsdv;
        }
        public List<Cachdung> getcachdung()
        {
            string query = string.Empty;
            query += "SELECT * FROM tblCACHDUNG";


            List<Cachdung> lscd = new List<Cachdung>();

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
                                Cachdung cd = new Cachdung();
                                cd.CachDung = reader["cachDung"].ToString();
                                lscd.Add(cd);

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
            return lscd;
        }
        public bool thaydoiCD(string cdmoi, string cdcu)
        {
            string query = string.Empty;
            query += "UPDATE [tblCACHDUNG] set cachDung=@cdmoi where cachDung=@cdcu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@cdmoi", cdmoi);
                    cmd.Parameters.AddWithValue("@cdcu", cdcu);

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

                return true;
            }
        }
        public bool thaydoiDV(string dvmoi, string dvcu)
        {
            string query = string.Empty;
            query += "UPDATE [tblDONVI] set donVi=@dvmoi where donVi=@dvcu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@dvmoi", dvmoi);
                    cmd.Parameters.AddWithValue("@dvcu", dvcu);

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

                return true;
            }
        }
        public bool xoaDV(string dv)
        {
            string query = string.Empty;
            query += "DELETE FROM tblDONVI WHERE donVi=@donVi";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@donVi", dv);
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

                return true;
            }
        }
        public bool xoaCD(string cd)
        {
            string query = string.Empty;
            query += "DELETE FROM tblCACHDUNG WHERE cachDung=@cachDung";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@cachDung", cd);
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

                return true;
            }
        }
        public bool themdv(string dv)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblDONVI] ([donVi])";
            query += "VALUES (@donVi)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@donVi", dv);
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
        public bool themcd(string cd)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblCACHDUNG] ([cachDung])";
            query += "VALUES (@cachDung)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@cachDung", cd);
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
