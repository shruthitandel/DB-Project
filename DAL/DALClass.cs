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

        public String userlogin(string username, string password)//checking the user name and password.If matched count 1 not 0.
        {
            try
            {
                con.Open();
                 password = encryptpass(password);
                SqlCommand cmd = new SqlCommand("select name from userdetails where username='" + username + "'and password='" + password + "'", con);
                String name = Convert.ToString(cmd.ExecuteScalar());
                return name;
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
                SqlCommand cmd = new SqlCommand("select count(*) from userdetails where username = '" + username + "'", con);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result == 0)
                {

                    SqlCommand cmd2 = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertdetail";
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

        public DataTable GetArtistTracks(string id)
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

        public int likeArtist(string artistid, string username, DateTime datetoday)
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

        public int checkIfLikeExist(string artistid, string username)//checking the user name and password.If matched count 1 not 0.
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

        public int dislikeArtist(string artistid, string username)
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

        public DataTable GetAlbumTracks(string id)
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

        public DataTable GetPlaylistFromCurrentUser(String name)
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
                cmd.CommandText = "uspGetNewPlaylist";
                cmd.Parameters.AddWithValue("@username", name);
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

        public DataTable GetUserFromCurrentPlaylist(String name)
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
                cmd.CommandText = "uspGetRecentPlaylist";
                cmd.Parameters.AddWithValue("@username", name);
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

        public DataTable GetRecentlyPlayedTracks(String name)
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
                cmd.CommandText = "getrecentplayedtracks";
                cmd.Parameters.AddWithValue("@username", name);
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

        public DataTable GetAllPlaylist(String name)
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
                cmd.CommandText = "uspGetAllPlaylist";
                cmd.Parameters.AddWithValue("@username", name);
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

        public DataTable GetNewAlbums()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetNewAlbums";
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

        public DataTable GetRecentTrackReleasedByLikedArtist(String name)
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
                cmd.CommandText = "uspGetRecentTracks";
                cmd.Parameters.AddWithValue("@username", name);
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

        public DataTable GetUserDetail(String name)
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
                cmd.CommandText = "uspGetUserDetails";
                cmd.Parameters.AddWithValue("@username", name);
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

        public DataTable GetPlaylistTracks(int id)
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
                cmd.CommandText = "givePlaylistTrack";
                cmd.Parameters.AddWithValue("@playlistid", id);
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

        public int createplaylist(string username, string playlisttype, string playlisttitle, DateTime todaydate, string trackid)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                con.Open();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "createplaylist";
                cmd1.Parameters.AddWithValue("@username", username);
                cmd1.Parameters.AddWithValue("@playlisttype", playlisttype);
                cmd1.Parameters.AddWithValue("@playlisttitle", playlisttitle);
                cmd1.Parameters.AddWithValue("@playlistreleasedate", todaydate);
                int playlistid = Convert.ToInt32(cmd1.ExecuteScalar());
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "getcountoftracksinplaylist";
                cmd2.Parameters.AddWithValue("@playlistid", playlistid);
                int tracknumber = Convert.ToInt32(cmd2.ExecuteScalar());
                tracknumber = tracknumber + 1;
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.CommandText = "addplaylistsong";
                cmd3.Parameters.AddWithValue("@playlistid", playlistid);
                cmd3.Parameters.AddWithValue("@trackid", trackid);
                cmd3.Parameters.AddWithValue("@tracknumber", tracknumber);
                int result = cmd3.ExecuteNonQuery();
                return result;





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

        public DataTable GetPlaylist(string username)
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
                cmd.CommandText = "giveplaylist";
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

        public int addinplaylist(int playlistid, string trackid)
        {
            try

            {
                SqlCommand cmd1 = new SqlCommand("select count(*) from PlayListSong where playlistid = '" + playlistid + " 'and trackid ='" + trackid + "'", con);

                con.Open();
                int result = Convert.ToInt32(cmd1.ExecuteScalar());
                if (result == 0)
                {

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;

                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "getcountoftracksinplaylist";
                    cmd2.Parameters.AddWithValue("@playlistid", playlistid);
                    int tracknumber = Convert.ToInt32(cmd2.ExecuteScalar());
                    tracknumber = tracknumber + 1;
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = con;
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "addplaylistsong";
                    cmd3.Parameters.AddWithValue("@playlistid", playlistid);
                    cmd3.Parameters.AddWithValue("@trackid", trackid);
                    cmd3.Parameters.AddWithValue("@tracknumber", tracknumber);
                    int a = cmd3.ExecuteNonQuery();
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

        public void addinsongplayed(DataTable dt, string albumid, string username)
        {
            try
            {

                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    string trackid = row["trackid"].ToString();
                    //string trackduration = row["trackduration"].ToString();
                    DateTime todaydate = DateTime.Now;
                    cmd.CommandText = "playalbum";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@trackid", trackid);
                    cmd.Parameters.AddWithValue("@albumid", albumid);
                    cmd.Parameters.AddWithValue("@playtime", todaydate);
                    cmd.ExecuteNonQuery();
                    con.Close();


                }


                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                con.Open();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "updatealbumcount";
                cmd2.Parameters.AddWithValue("@albumid", albumid);
                cmd2.ExecuteNonQuery();




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
        public void addinsongplayedplay(DataTable dt, int playlistid, string username)
        {
            try
            {

                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    string trackid = row["trackid"].ToString();
                    //string trackduration = row["trackduration"].ToString();
                    DateTime todaydate = DateTime.Now;
                    cmd.CommandText = "playplaylist";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@trackid", trackid);
                    cmd.Parameters.AddWithValue("@playlistid", playlistid);
                    cmd.Parameters.AddWithValue("@playtime", todaydate);
                    cmd.ExecuteNonQuery();
                    con.Close();


                }


                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                con.Open();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "updateplaylistcount";
                cmd2.Parameters.AddWithValue("@playlistid", playlistid);
                cmd2.ExecuteNonQuery();




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

        public int ratetrack(string username, string trackid, int rating, DateTime ratedate)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ratetracks";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@trackid", trackid);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@ratedate", ratedate);
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

        public int getrating(string username, string trackid)
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
                cmd.CommandText = "getrating";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@trackid", trackid);
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


        public int updateratetrack(string username, string trackid, int rating, DateTime ratedate)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updateratetracks";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@trackid", trackid);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@ratedate", ratedate);
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

        public DataTable GetUsersDetailsByKeyword(string keyword)
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
                cmd.CommandText = "uspGetUsers";
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

        public int followUser(string currentusername, string usernametobefollowed)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertfollowuser";
                cmd.Parameters.AddWithValue("@username", currentusername);
                cmd.Parameters.AddWithValue("@usernamefollow", usernametobefollowed);
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

        public int unFollowUser(string currentusername, string usernametobefollowed)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspUnfollowUser";
                cmd.Parameters.AddWithValue("@username", currentusername);
                cmd.Parameters.AddWithValue("@usernamefollow", usernametobefollowed);
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

        public int checkIfFollowExist(string username, string usernamefollow)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select COUNT(*) from FollowUser where username='" + username + "'and usernamefollow='" + usernamefollow + "'", con);
                cmd.Connection = con;
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

        public int updateUserDetails(string username, string name, string email, string city)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspUpdateUserDetails";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@city", city);
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
        public void addsongplayed(string username, string trackid, DateTime todaydate)
        {
            try
            {


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "trackadd";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@trackid", trackid);
                cmd.Parameters.AddWithValue("@playtime", todaydate);
                cmd.ExecuteNonQuery();
                con.Close();





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

        public void addsongplayed(string username, string trackid, int playlistid, DateTime todaydate)
        {
            try
            {


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "playplaylist";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@trackid", trackid);
                cmd.Parameters.AddWithValue("@playlistid", playlistid);
                cmd.Parameters.AddWithValue("@playtime", todaydate);
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                con.Open();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "updateplaylistcount";
                cmd2.Parameters.AddWithValue("@playlistid", playlistid);
                cmd2.ExecuteNonQuery();
                con.Close();




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

        public void addsongplayed(string username, string trackid, string albumid, DateTime todaydate)
        {
            try
            {


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "playalbum";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@trackid", trackid);
                cmd.Parameters.AddWithValue("@albumid", albumid);
                cmd.Parameters.AddWithValue("@playtime", todaydate);
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                con.Open();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "updatealbumcount";
                cmd2.Parameters.AddWithValue("@albumid", albumid);
                cmd2.ExecuteNonQuery();
                con.Close();




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
            
        

    









