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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLLClass bl = new BLLClass();
            if (Session["username"] != null)
            {
                String username = (String)Session["username"];
                System.Data.DataTable dt = bl.GetUserDetail(username);
                string result = "";
                result += "<table align='center' border='0' cellpadding='5'>";
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["name"].ToString();
                    string email = row["email"].ToString();
                    string city = row["city"].ToString();
                    result += "<tr><td align='center' valign='center'> Username </td><td>"
                        + username + "</td></tr>";
                    result += "<tr><td align='center' valign='center'> Name </td><td>"
                        + name + "</td></tr>";
                    result += "<tr><td align='center' valign='center'> Email </td><td>"
                       + email + "</td></tr>";
                    result += "<tr><td align='center' valign='center'> City </td><td>"
                       + city + "</td></tr>";
                }
                result += "</table>";
                DIV.InnerHtml = result;
               
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

            }  }
    }
}