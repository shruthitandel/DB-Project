﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BO;
using System.Collections;
using System.Data;

namespace ProjectDB
{
    public partial class SearchMusic : System.Web.UI.Page
    {
        BLLClass bl = new BLLClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                TextBox1.Text = "";
                Label1.Visible = false;
                DIV1.Visible = false;
                DIV2.Visible = false;
                DIV3.Visible = false;
                DIV4.Visible = false;
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                LinkButton4.Visible = false;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Label1.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DIV1.Visible = true;
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            string result1 = "";
            string result2 = "";
            string result3 = "";
            string result4 = "";
            string keyword = TextBox1.Text;
             DataTable dt1 = bl.GetTracksByKeyword(keyword, "cindy123");
             DataTable dt2 = bl.GetArtistsByKeyword(keyword);
             DataTable dt3 = bl.GetAlbumsByKeyword(keyword);
             DataTable dt4 = bl.GetPlayListByKeyword(keyword,"cindy123");
            foreach (DataRow row in dt1.Rows)
            {
                string tracktitle = row["tracktitle"].ToString();
                string artistname = row["artistname"].ToString();
                string trackDuration = row["trackDuration"].ToString();
                result1 += "<h2>" + tracktitle + "</h2><p>" + artistname + "</p><p>" + trackDuration + "</p>";
            }

            foreach (DataRow row in dt2.Rows)
            {
                string artistname = row["artistname"].ToString();
                result2 += "<h2>" + artistname + "</h2>";
            }

            foreach (DataRow row in dt3.Rows)
            {
                string albumname = row["albumtitle"].ToString();
                result3 += "<h2>" + albumname + "</h2>";
            }
            foreach (DataRow row in dt4.Rows)
            {
                string playlistname = row["playlisttitle"].ToString();
                result4 += "<h2>" + playlistname + "</h2>";
            }

            DIV1.InnerHtml = result1;
            DIV2.InnerHtml = result2;
            DIV3.InnerHtml = result3;
            DIV4.InnerHtml = result4;




        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DIV1.Visible = true;
            DIV2.Visible = false;
            DIV3.Visible = false;
            DIV4.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DIV1.Visible = false;
            DIV2.Visible = true;
            DIV3.Visible = false;
            DIV4.Visible = false;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            DIV1.Visible = false;
            DIV2.Visible = false;
            DIV3.Visible = true;
            DIV4.Visible = false;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

            DIV1.Visible = false;
            DIV2.Visible = false;
            DIV3.Visible = false;
            DIV4.Visible = true;
        }
    }
}