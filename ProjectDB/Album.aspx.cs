using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Microsoft.Security.Application;

namespace ProjectDB
{
    public partial class Album : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        DataTable dt;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            string albumid;

            if (Request.QueryString["albumid"] != null)
            {
                albumid = Convert.ToString(Encoder.HtmlAttributeEncode(Request.QueryString["albumid"]));
                dt = bl.GetAlbumTracks(albumid);
                string result = "";
                result += "<table><tr><td align='center' valign='center'> <img src='/assets/playlist.png' alt='description here' /></td>";
                foreach (DataRow row in dt.Rows)
                {
                    string tracktitle = row["tracktitle"].ToString();
                    string trackduration = row["trackduration"].ToString();
                    string trackid = row["trackid"].ToString();
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
            string albumid;
            if (Request.QueryString["albumid"] != null)
            {
                albumid = Convert.ToString(Encoder.HtmlAttributeEncode(Request.QueryString["albumid"]));
                bl.addinsongplayed(dt, albumid, username);
                string result = "<iframe src='https://open.spotify.com/embed?uri=spotify:album:" + albumid + "' width='1000' height='1000' frameborder='0' allowtransparency='true'></iframe>";
                //string result = "<iframe src='https://open.spotify.com/embed?uri=spotify:album:0K4pIOOsfJ9lK8OjrZfXzd' frameborder='0' allowtransparency='true'></iframe>";
                DIV.InnerHtml = result;

            }
           
        }
    }
}