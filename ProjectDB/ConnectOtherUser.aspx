<%@ Page Title="" Language="C#" MasterPageFile="~/Music.Master" AutoEventWireup="true" CodeBehind="ConnectOtherUser.aspx.cs" Inherits="ProjectDB.ConnectOtherUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
<style>
    .h1Style {
        font-size: 36px;
        line-height: 44px;
        letter-spacing: -.005em;
        font-weight: 600;
        color: gray;
        text-transform: none;
        margin: 24px 0;
        top:15px;
        position: relative;
                
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

.search-item a {
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

@import url(https://fonts.googleapis.com/css?family=Open+Sans);

body{
  background: #f2f2f2;
  font-family: 'Open Sans', sans-serif;
}

.search {
  width: 100%;
  position: relative;
}

.searchTerm {
  float: left;
  width: 100%;
  border: 3px solid Grey;
  padding: 5px;
  height: 20px;
  border-radius: 5px;
  outline: none;
  color: Grey;
}

.searchTerm:focus{
  color: black;
}

.searchButton {
  position: fixed;  
  right: -50px;
  width: 40px;
  height: 36px;
  border: 1px solid Grey;
  background: Grey;
  text-align: center;
  color: #fff;
  border-radius: 5px;
  cursor: pointer;
  font-size: 20px;
}

/*Resize the wrap to see the search bar change!*/
.wrap{
  width: 30%;
  position: relative;
  top: 30px;
  left: 50%;
  transform: translate(-50%, -50%);
}

table tr {display:inline}

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
   <div style="position: relative; top:80px; z-index:-1">
  <h1 class="h1Style" style="text-align: center;"> Search Users</h1>
       <div class="wrap">
   <div class="search">
      <input type="text" class="searchTerm" placeholder="Search Users" id="txtNickname" runat="server">
      <button type="submit" class="searchButton" runat="server" onserverclick="Button1_Click">
          <i class="fa fa-search"></i>
     </button>
        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only alphabets" ControlToValidate="txtNickname" ForeColor="Red" ValidationExpression="^[a-zA-Z\\s]+$"></asp:RegularExpressionValidator>--%>
   </div>
</div>
    <div id ="DIV" runat ="server"></div>
  </div>
</asp:Content>
