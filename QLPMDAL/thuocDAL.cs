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
    }
}
