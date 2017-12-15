using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using System.Text.RegularExpressions;
using Microsoft.Security.Application;

namespace ProjectDB
{
    public partial class Login : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Name"] != null && Session["username"] != null)
            {
                Response.Redirect("Home.aspx", false);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string useraname = Encoder.HtmlAttributeEncode(TextBox1.Value);
            System.Diagnostics.Debug.WriteLine(useraname);
            string password = Encoder.HtmlAttributeEncode(TextBox2.Value);
            /*if(useraname==null|| useraname == ""|| password ==null || password == "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Please enter username and password');", true);
                return;
            }

            if (!isAlphaNumeric(useraname))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Please enter only Aphanumeric username');", true);
                return;
            }*/
            String name = bl.userlogin(useraname, password); // added for fetching name of the signed in user

            if (name != null && name != "")
            {
                Session["Name"] = name;
                Session["username"] = useraname;
                Response.Redirect("Home.aspx", false);

            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Invalid Credentials.');", true);
            }
        }

        /* public static Boolean isAlphaNumeric(string strToCheck)
         {
             Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
             return rg.IsMatch(strToCheck);
         }*/
    }
}