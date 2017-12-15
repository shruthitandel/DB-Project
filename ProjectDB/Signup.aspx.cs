using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Text.RegularExpressions;

namespace ProjectDB
{
    public partial class Signup : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string email = TextBox2.Text;
            string username = TextBox3.Text;
            string password = TextBox4.Text;
            string repassword = TextBox5.Text;
            string city = TextBox6.Text;
            /*if(name==null|| name=="" || email == null || email =="" || username == null || username == "" || password == null || password == "" || city == null || city == "" )
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('All Fields are Mandatory');", true);
                return;
            }*/

            if (!isAlphaNumeric(name) || !isAlphaNumeric(username) || !isAlphaNumeric(city))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Either Name, username or city is Not Aphanumeric');", true);
                return;
            }

            if (!password.Equals(repassword))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Password does not match');", true);
                return;
            }
            int result = bl.insertuserdetails(name, email, username, password, city);
            if (result != 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Registration is successfull'); window.location ='Login.aspx'", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Username already exists.');", true);
            }
        }

        public static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }
    }
}