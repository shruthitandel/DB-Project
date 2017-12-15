using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Microsoft.Security.Application;

namespace ProjectDB
{
    public partial class Playlist : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int playlistid;
            int count = 0;
            if (Request.QueryString["playlistid"] != null)
            {
                playlistid = Convert.ToInt32(Encoder.HtmlAttributeEncode(Request.QueryString["playlistid"]));
                dt = bl.GetPlaylistTracks(playlistid);
                string result = "";
                result += "<table cellspacing='0' cellpadding='0'><tr><td align='center' valign='center'> <img src='/assets/playlist.png' alt='description here' />";
                foreach (DataRow row in dt.Rows)
                {
                    string tracktitle = row["tracktitle"].ToString();
                    string trackduration = row["trackduration"].ToString();
                    string trackid = Convert.ToString(row["trackid"]);
                    count = count + 1;
                    result += "<tr><td><a href='Tracks.aspx?trackid=" + trackid + "' runat ='server'>" + tracktitle + "</td><td>" + trackduration + "</td>";
                }
                result += "</tr></table>";
                DIV.InnerHtml = result;


            }

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

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string username = (String)Session["username"];
            int playlistid;
            if (Request.QueryString["playlistid"] != null)
            {
                playlistid = Convert.ToInt32(Encoder.HtmlAttributeEncode(Request.QueryString["playlistid"]));
                bl.addinsongplayedplay(dt, playlistid, username);
            }
        }
    }
}