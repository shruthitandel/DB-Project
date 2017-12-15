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
    public partial class ConnectOtherUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLLClass bl = new BLLClass();
            if (Request.QueryString["followuser"] != null )
            {
                
                bl.followUser((String)Session["username"], (String)Encoder.HtmlAttributeEncode(Request.QueryString["followuser"]));
                string scriptText = "alert('Followed Successfully'); window.location='" + Request.ApplicationPath + "ConnectOtherUser.aspx'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
                
                
            }
            else if(Request.QueryString["unfollowuser"] != null)
            {
                bl.unFollowUser((String)Session["username"], (String)Encoder.HtmlAttributeEncode(Request.QueryString["unfollowuser"]));
                string scriptText = "alert('UnFollowed Successfully'); window.location='" + Request.ApplicationPath + "ConnectOtherUser.aspx'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);

            }
            else
            {
                DIV.InnerHtml = "";
            }

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
            DIV.InnerHtml = "";
            BLLClass bl = new BLLClass();
            if (Session["username"] == null || Session["name"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["username"] != null)
            {
                String keyword = txtNickname.Value;
                System.Data.DataTable dt = bl.GetUsersDetailsByKeyword(keyword);
                string result = "";
                result += "<table align='left' border='0' cellpadding='5' style='top:155px; left:160px; position: absolute; overflow-y: scroll;'>";
                if (dt.Rows.Count == 0)
                {
                    result += "<tr><td>No Users Found</td></tr></table>";
                    DIV.InnerHtml = result;
                }
                else
                {
                    Boolean flagUserNameCheck = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        string name = row["name"].ToString();
                        string city = row["city"].ToString();
                        string username = row["username"].ToString();

                        if ((String)Session["username"] == username)
                        {
                            flagUserNameCheck = true;
                        }
                        else
                        {
                            string follow = "";
                            if (bl.checkIfFollowExists((String)Session["username"], username) > 0)
                            {
                                follow = "<a class='connectButton' href = '/ConnectOtherUser.aspx?unfollowuser=" + username + "'>unfollow</a>";
                            }
                            else
                            {
                                follow = "<a class='connectButton' href = '/ConnectOtherUser.aspx?followuser=" + username + "'>follow</a>";
                            }
                            result += "<tr><td align='center' valign='center'> <img src='/assets/user.png' alt='description here' /></br>"
                          + username + "</br>" + name + "</br>" + city + " </br>" + follow + "</td><tr>";
                                                    
                        }
                    }
                    if (flagUserNameCheck && dt.Rows.Count == 1)
                    {
                        result += "<tr><td>No Users Found</td></tr></table>";
                        DIV.InnerHtml = result;
                    }

                    else
                    {
                        result += "</tr></table>";
                        DIV.InnerHtml = result;
                    }
                }
                
            }
            }
        protected void Button_Click_Connect(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Connected Successfully');", true);
        }
        }
}