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
    public partial class Tracks : System.Web.UI.Page
    {
        string trackid;
        string albumid;
        int playlistid;
        string username;
        BLLClass bl = new BLLClass();
        int getrating = 0;
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel4.Visible = false;
            trackid = (Encoder.HtmlAttributeEncode(Request.QueryString["trackid"]));
            string track = "<iframe src='https://open.spotify.com/embed?uri=spotify:track:" + trackid + "' width='300' height='80' frameborder='0' allowtransparency='true'></iframe>";
            DIV5.InnerHtml = track;
            username = (String)Session["username"];
            if (Request.QueryString.AllKeys.Contains("albumid"))
            {
                albumid = Request.QueryString["albumid"];
            }
            if (Request.QueryString.AllKeys.Contains("playlistid"))
            {
                playlistid = Convert.ToInt32((Request.QueryString["playlistid"]));
            }


            getrating = bl.getrating(username, trackid);
            if (getrating != 0)
            {
                Label1.Visible = true;
                Label1.Text = "Your rating is " + getrating;
            }
            else
            {
                Label1.Visible = false;
            }
            Panel3.Visible = false;
            //string username = (String)Session["username"];

            String username1 = (String)Session["username"];
            System.Data.DataTable dt_recentlyplayedtracks = bl.GetRecentlyPlayedTracks(username1);
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


            if (Request.QueryString["trackid"] != null)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                string username = (String)Session["username"];
                DropDownList1.Items.Clear();
                DataTable dt = bl.getPlaylist(username);
                DropDownList1.DataSource = dt;
                DropDownList1.Items.Insert(0, "-- Select a Value --");
                DropDownList1.DataTextField = "playlisttitle";
                DropDownList1.DataValueField = "playlistid";
                DropDownList1.DataBind();
                count = count + 1;



            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["trackid"] != null)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            trackid = Encoder.HtmlAttributeEncode(Request.QueryString["trackid"]);
            string playlisttitle = TextBox1.Text;
            string playlisttype = RadioButtonList1.SelectedItem.Value.ToString();
            DateTime todaydate = DateTime.Now;
            string username = (String)Session["username"];
            int result = bl.createplaylist(username, playlisttype, playlisttitle, todaydate, trackid);
            if (result != 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Your Playlist is created');", true);
                DropDownList1.Items.Clear();

                Panel1.Visible = false;
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Sorry some error in creating the playlist.');", true);
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int playlistid = Convert.ToInt32(DropDownList1.SelectedValue);
            trackid = Encoder.HtmlAttributeEncode(Request.QueryString["trackid"]);
            int result = bl.addinplaylist(playlistid, trackid);
            if (result != 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Successfully added');", true);
                count = 1;
                Panel1.Visible = false;
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('The Track already exists in the playlist');", true);
                count = 1;
            }



        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            Panel3.Visible = true;




        }



        protected void Button5_Click(object sender, EventArgs e)
        {




            Panel4.Visible = true;
            if (playlistid == 0 && albumid == "")
            {
                DateTime datetoday = DateTime.Now;

                bl.addsongplayed(username, trackid, datetoday);
            }





        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            int rating = Convert.ToInt32(RadioButtonList2.SelectedItem.Value.ToString());
            DateTime ratedate = DateTime.Now;
            trackid = Encoder.HtmlAttributeEncode(Request.QueryString["trackid"]);
            string username = (String)Session["username"];
            if (getrating == 0)
            {
                int result = bl.ratetrack(username, trackid, rating, ratedate);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Successfully rated');window.location='Tracks.aspx';", true);
                    Panel3.Visible = false;
                    RadioButtonList2.SelectedItem.Value = "";
                    Response.Redirect("Tracks.aspx?trackid=" + trackid);

                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Some error');", true);
                }
            }

            else
            {
                int result = bl.updateratetrack(username, trackid, rating, ratedate);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Successfully rated');", true);
                    Panel3.Visible = false;
                    RadioButtonList2.SelectedItem.Value = "";
                    Response.Redirect("Tracks.aspx?trackid=" + trackid);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Some error');", true);
                }
            }

        }



        protected void Button5_Click2(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            Panel3.Visible = false;
            if (playlistid == 0 && albumid == null)
            {
                DateTime datetoday = DateTime.Now;

                bl.addsongplayed(username, trackid, datetoday);
            }
            if (playlistid != 0 && albumid == null)
            {
                DateTime datetoday = DateTime.Now;

                bl.addsongplayed(username, trackid, playlistid, datetoday);
            }
            if (playlistid == 0 && albumid != null)
            {
                DateTime datetoday = DateTime.Now;

                bl.addsongplayed(username, trackid, albumid, datetoday);
            }
        }
    }
}