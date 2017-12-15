using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BO;
using System.Collections;
using System.Data;
using Microsoft.Security.Application;

namespace ProjectDB
{
    public partial class SearchMusic : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "";
                DIV1.Visible = false;
                DIV2.Visible = false;
                DIV3.Visible = false;
                DIV4.Visible = false;
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                LinkButton4.Visible = false;
            }
            string username = (String)Session["username"];
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            DIV1.Visible = true;
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            string result1 = "";
            string result2 = "";
            string result3 = "";
            string result4 = "";
            string keyword = Encoder.HtmlAttributeEncode(TextBox1.Text);
            string username = (String)Session["username"];
            DataTable dt1 = bl.GetTracksByKeyword(keyword, username);
            DataTable dt2 = bl.GetArtistsByKeyword(keyword);
            DataTable dt3 = bl.GetAlbumsByKeyword(keyword);
            DataTable dt4 = bl.GetPlayListByKeyword(keyword, username);
            result1 += "<table><th>Track Name</th><th>ArtistName</th><th>Track Duration</th>";
            foreach (DataRow row in dt1.Rows)
            {
                string tracktitle = row["tracktitle"].ToString();
                string artistname = row["artistname"].ToString();
                string trackDuration = row["trackDuration"].ToString();
                string artistid = row["artistid"].ToString();
                string trackid = row["trackid"].ToString();
                result1 += "<tr><td><a href='Tracks.aspx?trackid=" + trackid + "' runat ='server'>" + tracktitle + "</a></td><td><a href='Artists.aspx?artistid=" + artistid + "' runat ='server'>" + artistname + " </a></td><td>" + trackDuration + "</td></tr>";
                //result1 += "<h2><a href='Tracks.aspx' runat ='server'>" + tracktitle + "</a></h2><p><a href='Artists.aspx' runat ='server'>" + artistname + " </a></p><p>" + trackDuration + "</p>";
            }

            foreach (DataRow row in dt2.Rows)
            {
                string artistname = row["artistname"].ToString();
                string artistid = row["artistid"].ToString();
                //Session["artistid"] = artistid;
                result2 += "<h2><a href='Artists.aspx?artistid=" + artistid + "' runat ='server'>" + artistname + "</a></h2>";
            }

            foreach (DataRow row in dt3.Rows)
            {
                string albumname = row["albumtitle"].ToString();
                string albumid = row["albumid"].ToString();
                //Session["albumid"] = albumid;
                result3 += "<h2><a href='Album.aspx?albumid=" + albumid + "' runat ='server'>" + albumname + "</a> </h2>";
            }
            foreach (DataRow row in dt4.Rows)
            {
                string playlistname = row["playlisttitle"].ToString();
                int playlistid = Convert.ToInt32(row["playlistid"]);
                result4 += "<h2><a href='Playlist.aspx?playlistid=" + playlistid + "' runat ='server'>" + playlistname + " </a></h2>";
            }

            DIV1.InnerHtml = result1;
            DIV2.InnerHtml = result2;
            DIV3.InnerHtml = result3;
            DIV4.InnerHtml = result4;


            

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DIV1.Visible = true;
            DIV2.Visible = false;
            DIV3.Visible = false;
            DIV4.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DIV1.Visible = false;
            DIV2.Visible = true;
            DIV3.Visible = false;
            DIV4.Visible = false;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            DIV1.Visible = false;
            DIV2.Visible = false;
            DIV3.Visible = true;
            DIV4.Visible = false;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

            DIV1.Visible = false;
            DIV2.Visible = false;
            DIV3.Visible = false;
            DIV4.Visible = true;
        }
    }
}
