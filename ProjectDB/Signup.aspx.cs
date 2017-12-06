using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

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
            int result = bl.insertuserdetails(name, email, username, password, city);
            if (result != 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Registeration is successfull');window.location='Login.aspx';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Username already exists.');", true);
            }
        }
    }
}