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
    public partial class Artists : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        string artistid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["artistid"] != null)
            {
                artistid = Convert.ToString(Encoder.HtmlAttributeEncode(Request.QueryString["artistid"]));
                string userName1 = (String)Session["username"];
                int b = bl.checkIfLikeExist(artistid, userName1);
                if (b == 1)
                {
                    Button1.Visible = false;
                    Button2.Visible = true;

                }
                else
                {
                    Button1.Visible = true;
                    Button2.Visible = false;
                }

                DataTable dt = bl.GetArtistTracks(artistid);
                string result = "";
                result += "<table><tr><td align='center' valign='center'> <img src='/assets/user.png' alt='description here' />";
                foreach (DataRow row in dt.Rows)
                {
                    string tracktitle = row["tracktitle"].ToString();
                    string trackduration = row["trackduration"].ToString();
                    string trackid = row["trackid"].ToString();
                    result += "<tr><td><a href='Tracks.aspx?trackid=" + trackid + "' runat ='server'>" + tracktitle + " </td><td>" + trackduration + "</td>";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime datetoday = DateTime.Today;
            string username = (String)Session["username"];
            int a = bl.likeArtist(artistid, username, datetoday);
            if (a != 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('You have successfully like the artist');", true);
            }
            Button1.Visible = false;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string username = (String)Session["username"];
            int c = bl.dislikeArtist(artistid, username);
            if (c != 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('You have successfully unlike the artist');", true);
                Button1.Visible = true;
                Button2.Visible = false;
            }

        }
    }
}