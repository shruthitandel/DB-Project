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
    public partial class AllPlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLLClass bl = new BLLClass();
            if (Session["username"] == null || Session["name"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["username"] != null)
            {
                String username = (String)Session["username"];
                System.Data.DataTable dt_playlist = bl.GetAllPlaylist(username);
                String result_playlist = "<table align = 'center' border = '0' cellpadding = '5'><tr> ";

                foreach (DataRow row in dt_playlist.Rows)
                {
                    string playlisttitle = row["playlisttitle"].ToString();
                    string playlistid = row["playlistid"].ToString();


                    result_playlist += "<td align='center' valign='center'> <img src='/assets/playlist.png' alt='description here' /></br>" +
                        "<a href='/Playlist.aspx?playlistid=" + playlistid + "'>" + playlisttitle + "</a></td>";

                }
                result_playlist += "</tr></table>";
                if (dt_playlist.Rows.Count > 0)
                {
                    DIV.InnerHtml = result_playlist;
                }

                
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

            }
        }
    }
}