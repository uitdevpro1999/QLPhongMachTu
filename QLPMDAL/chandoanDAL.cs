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

    public class ChandoanDAL
    {
        private string connectionString;

        public ChandoanDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool them(ChandoanDTO cd)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblKQCHANDOAN] ([maBenh], [maPKB]) ";
            query += "VALUES (@maBenh,@maPKB)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maBenh", cd.MaBenh);
                    cmd.Parameters.AddWithValue("@maPKB", cd.MaPkb);
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
        public List<ChandoanDTO> select()
        {
            string query = string.Empty;
            query += "SELECT * ";
            query += "FROM [tblKQCHANDOAN]";

            List<ChandoanDTO> lscd = new List<ChandoanDTO>();

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
                                ChandoanDTO cd = new ChandoanDTO();
                                cd.MaPkb = reader["maPKB"].ToString();
                                cd.MaBenh = reader["maBenh"].ToString();
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
    }
}
