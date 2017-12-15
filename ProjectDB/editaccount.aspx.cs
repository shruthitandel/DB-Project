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
    public partial class editaccount : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            BLLClass bl = new BLLClass();
            if (Session["username"] != null)
            {
                String username = (String)Session["username"];
                System.Data.DataTable dt = bl.GetUserDetail(username);
               
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["name"].ToString();
                    string email = row["email"].ToString();
                    string city = row["city"].ToString();
                    if (!Page.IsPostBack)
                    {
                    dname.Value=name;
                    demail.Value= Encoder.HtmlAttributeEncode(email);
                    dcity.Value= Encoder.HtmlAttributeEncode(city);
                    }

                }

               
                System.Data.DataTable dt_recentlyplayedtracks = bl.GetRecentlyPlayedTracks(username);
                String result_recentlyplayedtracks = "<div class='search-item-lesswidth'><div> Recently Played Tracks</div>";

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
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            string useraname = (String)Session["username"] ;
           // string myname = ;
            string name = dname.Value;
            string email = Encoder.HtmlAttributeEncode(demail.Value);
            string city = Encoder.HtmlAttributeEncode(dcity.Value); ;
            int value = bl.updateUserDetails(useraname, name, email, city);
            // added for fetching name of the signed in user

            string scriptText = "alert('Account Updated Successfully'); window.location='" + Request.ApplicationPath + "myaccount.aspx'";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
            //ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Account Updated Successfully');", true);
            //Response.Redirect("myaccount.aspx", false);

           }
    }
}