using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPMDTO;
using System.Data.SqlClient;
using System.Configuration;
namespace QLPMDAL
{
    public class PhieukhambenhDAL
    {
        private string connectionString;

        public PhieukhambenhDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool them(PhieukhambenhDTO pkb)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblPKB] ([maPKB],[NgayKham])";
            query += "VALUES (@maPKB,@NgayKham)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPKB", pkb.MaPkb);
                    cmd.Parameters.AddWithValue("@NgayKham", pkb.NgayKham);

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
        public bool sua(PhieukhambenhDTO pkb)
        {
            string query = string.Empty;
            query += "update [tblPKB]";
            query += "set TrieuChung=@TrieuChung where maPKB=@maPKB";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPKB", pkb.MaPkb);
                    cmd.Parameters.AddWithValue("@TrieuChung", pkb.TrieuChung);
                    //cmd.Parameters.AddWithValue("@NgayKham", pkb.NgayKham);
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
        public int autogenerate_mapkb()
        {
            int mapkb = 1;
            string query = string.Empty;
            query += "SELECT MAX (KQ.MAPKB) AS MM from (SELECT CONVERT(float, tblPKB.maPKB) AS MAPKB FROM tblPKB ) AS KQ";

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
                                mapkb = int.Parse(reader["MM"].ToString()) + 1;
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
            return mapkb;
        }
        public List<PhieukhambenhDTO> select()
        {
            string query = string.Empty;
            query += "SELECT * ";
            query += "FROM [tblPKB]";

            List<PhieukhambenhDTO> lspkb = new List<PhieukhambenhDTO>();

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
                                PhieukhambenhDTO pkb = new PhieukhambenhDTO();
                                pkb.MaPkb = reader["maPKB"].ToString();
                                pkb.TrieuChung = reader["TrieuChung"].ToString();
                                pkb.NgayKham = DateTime.Parse(reader["NgayKham"].ToString());
                                lspkb.Add(pkb);

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
            return lspkb;
        }
        public List<PhieukhambenhDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT * ";
            query += " FROM [tblPKB]";
            query += " WHERE ([maPKB] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([NgayKham]=@sKeyword)";

            List<PhieukhambenhDTO> lspkb = new List<PhieukhambenhDTO>();

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
                                PhieukhambenhDTO pkb = new PhieukhambenhDTO();
                                pkb.MaPkb = reader["maPKB"].ToString();
                                pkb.TrieuChung = reader["TrieuChung"].ToString();
                                pkb.NgayKham = DateTime.Parse(reader["NgayKham"].ToString());
                                lspkb.Add(pkb);

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
            return lspkb;
        }
        public void tk()
        {
            string query = string.Empty;
            query += "SELECT * FROM tblTK ";
 
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
                                PhieukhambenhDTO.TienKham = float.Parse(reader["tienKham"].ToString());
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
        }
        public bool thaydoiTK(float tkmoi,float tkcu)
        {
            string query = string.Empty;
            query += "UPDATE [tblTK] set tienKham=@tkmoi where tienKham=@tkcu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tkmoi", tkmoi);
                    cmd.Parameters.AddWithValue("@tkcu", tkcu);
                   
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
        public bool drop_trigger_khamtoida()
        {
            string query = string.Empty;
            query += "USE [QLPM]\r\nIF EXISTS (SELECT * FROM sys.objects WHERE [name] = 'kham_toida1')\r\nBEGIN\r\nDROP TRIGGER [dbo].[kham_toida1];\r\nEND;\r\n";
         
 
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
        public bool thaydoi_khamtoida(int khamtoida)
        {
            string query = string.Empty;
            query += "EXEC sp_executeSQL N'Create Trigger kham_toida1 ON tblPKB FOR INSERT AS BEGIN IF(Select Count(a.maPKB) From tblPKB a Inner Join INSERTED b On a.NgayKham = b.NgayKham) > 80 BEGIN ROLLBACK TRANSACTION END END'";
            string triggername = "kham_toida1";

            string tablename = "tblPKB";


            StringBuilder cmd = new StringBuilder();
            
            cmd.AppendLine("EXEC sp_executeSQL");
            cmd.AppendLine("N'");


            cmd.AppendLine(string.Format("CREATE TRIGGER dbo.{0}", triggername));

            cmd.AppendLine(string.Format("ON dbo.{0}", tablename));

            cmd.AppendLine("AFTER INSERT");

            cmd.AppendLine("AS begin");

            cmd.AppendLine(string.Format("IF(Select Count(a.maPKB) From tblPKB a Inner Join INSERTED b On a.NgayKham = b.NgayKham) > {0}",khamtoida));

            cmd.AppendLine("BEGIN");


            cmd.AppendLine("ROLLBACK TRANSACTION");

            cmd.AppendLine("END");

            cmd.AppendLine("END");

            cmd.AppendLine("'");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = con;
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = cmd.ToString() ;
                    //cm.Parameters.AddWithValue("@khamtoida", khamtoida);
                    try
                    {
                        con.Open();
                        cm.ExecuteNonQuery();
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
    }
}
