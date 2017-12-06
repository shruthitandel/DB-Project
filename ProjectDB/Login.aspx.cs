using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace ProjectDB
{
    public partial class Login : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string useraname = TextBox1.Text;
            string password = TextBox2.Text;
            int a = bl.userlogin(useraname, password);
            if (a != 0)
            {
                Session["username"] = useraname;
                Response.Redirect("Home.aspx");

            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Invalid Credentials.');", true);
            }
        }
    }
}