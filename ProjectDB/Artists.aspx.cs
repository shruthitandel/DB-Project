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
    public partial class Artists : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        int artistid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["artistid"] != null)
            {
                artistid = Convert.ToInt32(Request.QueryString["artistid"]);
                string userName1 = "cindy123";
                int b = bl.checkIfLikeExist(artistid, userName1);
                if(b == 1)
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
                result += "<table>";
                foreach (DataRow row in dt.Rows)
                {
                    string tracktitle = row["tracktitle"].ToString();
                    string trackduration = row["trackduration"].ToString();
                    result += "<tr><td>" + tracktitle + "</td><td>" + trackduration + "</td>";
                }
                result += "</table>";
                DIV.InnerHtml = result;

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime datetoday = DateTime.Today;
            string username = "cindy123";
            int a = bl.likeArtist(artistid,username,datetoday);
            if(a !=0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('You have successfully like the artist');", true);
            }
            Button1.Visible = false;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string username = "cindy123";
            int c = bl.dislikeArtist(artistid, username);
            if(c!=0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('You have successfully unlike the artist');", true);
                Button1.Visible = true;
                Button2.Visible = false;
            }

        }
    }
}