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
    public partial class Album : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            int albumid;
            if (Request.QueryString["albumid"] != null)
            {
                albumid = Convert.ToInt32(Request.QueryString["albumid"]);
                DataTable dt = bl.GetAlbumTracks(albumid);
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
    }
}