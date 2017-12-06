using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using BO;

namespace DAL
{
    public class DALClass
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True");

        public int userlogin(string username, string password)//checking the user name and password.If matched count 1 not 0.
        {
            try
            {
                con.Open();
                password = encryptpass(password);
                SqlCommand cmd = new SqlCommand("select count(*) from userdetail1 where username='" + username + "'and password='" + password + "'", con);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
       
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }


        public int insertuserdetails(string name, string emailid, string username, string password, string city)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from userdetail1 where username = '" + username + "'", con);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result == 0)
                {

                    SqlCommand cmd2 = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertuser";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@emailid", emailid);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", encryptpass(password));
                    cmd.Parameters.AddWithValue("@city", city);
                    int a = cmd.ExecuteNonQuery();
                    return a;
                }

                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetTracksByKeyword(string keyword, string username)
        {
            try
            {
                // List<BOClass> searchtrack = new List<BOClass>();
                // BOClass bo = new BOClass();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectTracks";
                cmd.Parameters.AddWithValue("@keyword", keyword);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable GetArtistsByKeyword(string keyword)
        {
            try
            {
                // List<BOClass> searchtrack = new List<BOClass>();
                // BOClass bo = new BOClass();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectArtist";
                cmd.Parameters.AddWithValue("@keyword", keyword);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable GetAlbumsByKeyword(string keyword)
        {
            try
            {
                // List<BOClass> searchtrack = new List<BOClass>();
                // BOClass bo = new BOClass();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAlbum";
                cmd.Parameters.AddWithValue("@keyword", keyword);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable GetPlayListByKeyword(string keyword, string username)
        {
            try
            {
                // List<BOClass> searchtrack = new List<BOClass>();
                // BOClass bo = new BOClass();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectPlayList";
                cmd.Parameters.AddWithValue("@keyword", keyword);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable GetArtistTracks(int id)
        {
            try
            {
                // List<BOClass> searchtrack = new List<BOClass>();
                // BOClass bo = new BOClass();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "giveArtistTrack";
                cmd.Parameters.AddWithValue("@artistid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public int likeArtist(int artistid, string username, DateTime datetoday)
        {
            try
            {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "likeArtists";
                    cmd.Parameters.AddWithValue("@artistid", artistid);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@likedate", datetoday);
                    int a = cmd.ExecuteNonQuery();
                    return a;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int checkIfLikeExist(int artistid, string username)//checking the user name and password.If matched count 1 not 0.
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "checkIfLikeExist";
                cmd.Parameters.AddWithValue("@artistid", artistid);
                cmd.Parameters.AddWithValue("@username", username);
                int a = cmd.ExecuteNonQuery();
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int dislikeArtist(int artistid, string username)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dislikeArtist";
                cmd.Parameters.AddWithValue("@artistid", artistid);
                cmd.Parameters.AddWithValue("@username", username);
                int a = cmd.ExecuteNonQuery();
                return a;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetAlbumTracks(int id)
        {
            try
            {
                // List<BOClass> searchtrack = new List<BOClass>();
                // BOClass bo = new BOClass();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "giveAlbumTrack";
                cmd.Parameters.AddWithValue("@albumid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }




    }

}
            
        

    









