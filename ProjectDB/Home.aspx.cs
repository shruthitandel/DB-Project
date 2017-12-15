using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace ProjectDB
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLLClass bl = new BLLClass();
            if (Session["username"] == null||Session["name"]==null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["username"] != null)
            {
                String username = (String)Session["username"];
               
                System.Data.DataTable dt_recentlyplayedtracks = bl.GetRecentlyPlayedTracks(username);
                String result_recentlyplayedtracks = "<div class='search-item-lesswidth'><p> Recently Played Tracks</p>";

                foreach (DataRow row in dt_recentlyplayedtracks.Rows)
                {
                    string tracktitle = row["tracktitle"].ToString();
                    string trackid = row["trackid"].ToString();


                    result_recentlyplayedtracks += "" +
                        "<a href='/Tracks.aspx?trackid=" + trackid + "'>" + tracktitle + "</a></br>";

                }
                result_recentlyplayedtracks += "</div>";
                if (dt_recentlyplayedtracks.Rows.Count > 0)
                {
                    DIV8.InnerHtml = result_recentlyplayedtracks;
                }

                
                

                System.Data.DataTable dt = bl.GetPlaylistFromCurrentUser(username);
                string result = "";
                result += "<table align='center' border='0' cellpadding='5'><tr>";
                foreach (DataRow row in dt.Rows)
                {
                    string playlisttitle = row["playlisttitle"].ToString();
                    string playlistid = row["playlistid"].ToString();
                    string usernamefollow = row["usernamefollow"].ToString();


                    result += "<td align='center' valign='center'> <img src='/assets/playlist.png' alt='description here' /></br>"+
                        "<a href='/Playlist.aspx?playlistid=" + playlistid + "'>" + playlisttitle + "</a> by "+ usernamefollow + "</td>";
                    
                }
                result += "</tr></table>";
                DIV.InnerHtml = result;

                System.Data.DataTable dt1 = bl.GetNewAlbums();
                string result1 = "";
                result1 += "<table align='center' border='0' cellpadding='5'><tr>";
                foreach (DataRow row1 in dt1.Rows)
                {
                    string albumtitle = row1["albumtitle"].ToString();
                    string albumId = row1["albumid"].ToString();

                    result1 += "<td align='center' valign='center'> <img src='/assets/album.png' alt='description here' /></br>" +
                        "<a href='/Album.aspx?albumid=" + albumId + "'>" + albumtitle + "</a></td>";
                }
                result1 += "</tr></table>";
                DIV1.InnerHtml = result1;

                System.Data.DataTable dt2 = bl.GetRecentTrackReleasedByLikedArtist(username);
                string result2 = "";
                result2 += "<table align='center' border='0' cellpadding='5'><tr>";
                foreach (DataRow row2 in dt2.Rows)
                {
                    string tracktitle = row2["tracktitle"].ToString();
                    string trackid = row2["trackid"].ToString();
                    string artistname = row2["artistname"].ToString();

                    result2 += "<td align='center' valign='center'> <img src='/assets/album.png' alt='description here' /></br>" +
                        "<a href='Tracks.aspx?trackid=" + trackid + "' runat ='server'>" + tracktitle + "</a> by "+ artistname + "</td>";
                }
                result2 += "</tr></table>";
                DIV2.InnerHtml = result2;


            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void getRecentAlbums_Click(object sender, EventArgs e)
        {
           // lblGetRecentAlbums.Text = "Yet to write query ";
        }
    }
}