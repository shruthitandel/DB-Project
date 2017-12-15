<%@ Page Title="" Language="C#" MasterPageFile="~/Music.Master" AutoEventWireup="true" CodeBehind="AllPlaylist.aspx.cs" Inherits="ProjectDB.AllPlaylist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 347px;
        }
        .auto-style3 {
            width: 337px;
        }
        .auto-style4 {
            width: 347px;
            height: 31px;
        }
        .auto-style5 {
            width: 337px;
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
        }
        .auto-style7 {
            width: 337px;
            text-align: center;
        }

        .nav-bar-container {
    width: 220px;
    position: fixed;
    top: 80px;
    left: 0;
    height: 100%;
    z-index: 100;
    background-color: rgba(0,0,0,.5);
    overflow: auto;
    min-height: 0!important;
    will-change: transform;
}

.navBar {
    padding: 24px;
    padding-bottom: 95px;
    display: -ms-flexbox;
    display: flex;
    -ms-flex-direction: column;
    flex-direction: column;
    height: 50%;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    cursor: default;
}

.navBar .search-item a {
    font-size: 15px;
    line-height: 22px;
    letter-spacing: .015em;
    font-weight: 600;
    padding: 3px 0;
    transition-property: color;
    transition-duration: .2s;
    transition-timing-function: linear;
    color: hsla(0,0%,100%,.6);
    padding:2px;
}

.search-item a {
    font-size: 15px;
    line-height: 22px;
    letter-spacing: .015em;
    font-weight: 600;
    padding: 3px 0;
    transition-property: color;
    transition-duration: .2s;
    transition-timing-function: linear;
    color: cornflowerblue;
    padding:2px;
}

 .h1Style {
        font-size: 36px;
        line-height: 44px;
        letter-spacing: -.005em;
        font-weight: 600;
        color: gray;
        text-transform: none;
        margin: 24px 0;
        top:80px;
        
    }
 table {
    width: 90%;
    text-align: center;
}

table tr td {
    width: 25%;
    word-wrap: break-word;
    display: inline-block;
    margin-top: 2px;
}

.search-item-lesswidth a {
    font-size: 10px;
    line-height: 16px;
    letter-spacing: .015em;
    font-weight: 600;
    padding: 2px 0;
    transition-property: color;
    transition-duration: .2s;
    transition-timing-function: linear;
    color: purple;
    padding:2px;
}
.search-item-lesswidth a p{
    font-size: 15px;
    line-height: 22px;
    letter-spacing: .015em;
    font-weight: 600;
    padding: 3px 0;
    transition-property: color;
    transition-duration: .2s;
    transition-timing-function: linear;
    color: black;
    padding:2px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="nav-bar-container">
<nav class="navBar">
    <div class="search-item"><a href="/Home.aspx">Home</a></div><br/>
    <div class="search-item"><a href="/SearchMusic.aspx">Search</a></div><br/>
    <div class="search-item"><a href="/myaccount.aspx">My Account</a></div><br/>
    <div class="search-item"><a href="/ConnectOtherUser.aspx">Connect Other User</a></div><br/>
      <div class="search-item"><a href="/AllPlaylist.aspx">My Playlist</a></div><br/>
     <div id ="DIV8" runat ="server"></div>
</nav></div>
         <div style="position: absolute; top:80px; z-index:-1; width:100%;">
               <h1 class="h1Style" style="text-align: center; ">All Playlist</h1>
        <div id ="DIV" runat ="server">
        </div>
                     </div>
  </asp:Content>