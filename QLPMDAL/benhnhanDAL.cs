using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLPMDTO;
using System.Configuration;
namespace QLPMDAL
{
    public class BenhNhanDAL
    {
        private string connectionString;

        public BenhNhanDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool them(BenhNhanDTO bn)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblBENHNHAN] ([maBN], [tenBN], [GioiTinh],[NgaySinh],[DiaChi],[maPKB])";
            query += "VALUES (@maBN,@tenBN,@GioiTinh,@NgaySinh,@DiaChi,@maPKB)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maBN", bn.MaBN);
                    cmd.Parameters.AddWithValue("@tenBN", bn.TenBN);
                    cmd.Parameters.AddWithValue("@GioiTinh", bn.GtBN);
                    cmd.Parameters.AddWithValue("@NgaySinh", bn.NgsinhBN);
                    cmd.Parameters.AddWithValue("@DiaChi", bn.DiachiBN);
                    cmd.Parameters.AddWithValue("@maPKB", bn.MaPKB);
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
        public bool sua(BenhNhanDTO bn,string maBNold)
        {
            string query = string.Empty;
            query += "update [tblBENHNHAN]";
            query += "set maBN=@maBN,tenBN=@tenBN,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,DiaChi=@DiaChi where maBN=@maBNold";
           
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maBN", bn.MaBN);
                    cmd.Parameters.AddWithValue("@tenBN", bn.TenBN);
                    cmd.Parameters.AddWithValue("@GioiTinh", bn.GtBN);
                    cmd.Parameters.AddWithValue("@NgaySinh", bn.NgsinhBN);
                    cmd.Parameters.AddWithValue("@DiaChi", bn.DiachiBN);
                    cmd.Parameters.AddWithValue("@maBNold", maBNold);
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
        public bool themmapkb(BenhNhanDTO bn, string mapkb)
        {
            string query = string.Empty;
            query += "update [tblBENHNHAN]";
            query += "set maPKB=@maPKB where maBN=@maBN";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maBN", bn.MaBN);
                    cmd.Parameters.AddWithValue("@maPKB", mapkb);
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
            public bool xoa(BenhNhanDTO bn)
        {
            string query = string.Empty;
            query += "delete from [tblBENHNHAN]";
            query += "where maBN=@maBN";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maBN", bn.MaBN);
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
        public List<BenhNhanDTO> select()
        {
            string query = string.Empty;
            query += "SELECT * ";
            query += "FROM [tblBenhNhan]";

            List<BenhNhanDTO> lsBenhNhan = new List<BenhNhanDTO>();

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
                                BenhNhanDTO bn = new BenhNhanDTO();
                                bn.MaBN = int.Parse(reader["maBN"].ToString());
                                bn.TenBN = reader["tenBN"].ToString();
                                bn.NgsinhBN = DateTime.Parse(reader["NgaySinh"].ToString());
                                bn.GtBN = reader["GioiTinh"].ToString();
                                bn.MaPKB = reader["maPKB"].ToString();
                                bn.DiachiBN = reader["DiaChi"].ToString();
                                lsBenhNhan.Add(bn);
                                
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
            return lsBenhNhan;
        }
        public List<BenhNhanDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT * ";
            query += " FROM [tblBENHNHAN]";
            query += " WHERE ([maBN] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenBN] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([NgaySinh] LIKE CONCAT('%',@sKeyword,'%'))";

            List<BenhNhanDTO> lsBenhNhan = new List<BenhNhanDTO>();

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
                                BenhNhanDTO bn = new BenhNhanDTO();
                                bn.MaBN = int.Parse(reader["maBN"].ToString());
                                bn.TenBN = reader["tenBN"].ToString();
                                bn.NgsinhBN = DateTime.Parse(reader["NgaySinh"].ToString());
                                bn.GtBN = reader["GioiTinh"].ToString();
                                bn.MaPKB = reader["maPKB"].ToString();
                                bn.DiachiBN = reader["DiaChi"].ToString();
                                lsBenhNhan.Add(bn);
                                
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
            return lsBenhNhan;
        }
    }
}
