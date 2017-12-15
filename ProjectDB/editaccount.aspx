<%@ Page Title="" Language="C#" MasterPageFile="~/Music.Master" AutoEventWireup="true" CodeBehind="editaccount.aspx.cs" Inherits="ProjectDB.editaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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


@import "http://fonts.googleapis.com/css?family=Droid+Serif";
/* Above line is used to import Google font style */
.maindiv{
margin:0 auto;
width:980px;
height:500px;
background:#fff;
padding-top:20px;
font-size:14px;
font-family:'Droid Serif',serif
}

.divA{
width:70%;
float:left;
margin-top:30px
}
.form{
width:400px;
float:left;
background-color:#f0f8ff;
font-family:'Droid Serif',serif;
padding-left:30px
}
.divB{
width:100%;
height:100%;
background-color:#f0f8ff;
border:dashed 1px #999
}
.divD{
width:200px;
height:480px;
float:left;
background-color:#f0f8ff;
border-right:dashed 1px #999
}

p{
font-weight:700;
text-align:center;
color:#5678C0;
font-size:18px;
text-shadow:2px 2px 2px #cfcfcf
}

.input{
width:250px;
height:15px;
border-radius:1px;
box-shadow:0 0 1px 2px #123456;
margin-top:10px;
padding:5px 0;
border:none;
margin-bottom:20px
}
.submit{
color:#fff;
border-radius:3px;
background:#1F8DD6;
padding:5px;
margin-top:40px;
border:none;
width:100px;
height:30px;
box-shadow:0 0 1px 2px #123456;
font-size:16px;
cursor: pointer;
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
.search-item-lesswidth div{
    font-size: 14px;
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

.login-page {
  width: 360px;
  padding: 8% 0 0;
  margin: auto;
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
      <h1 class="h1Style" style="text-align: center;"> Update User </h1>
<div class="login-form" style="text-align: center; position : fixed; left:42%;">

<label>Name:</label><br />
<input class='input' type='text' name='dname' id='dname' runat="server"/>
    </br>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"  ErrorMessage="Enter Name" ControlToValidate="dname" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="requiredfieldclass" ID="RegularExpressionValidator2" runat="server" ControlToValidate="dname" ErrorMessage="Aphabet only" Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
    <br />
<label>Email:</label><br />
<input class='input' type='text' name='demail' id='demail' runat="server"/>
    </br>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ErrorMessage="Enter Email Id" ControlToValidate="demail" ForeColor="Red"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator CssClass="requiredfieldclass" ID="RegularExpressionValidator4" runat="server" ControlToValidate="demail" ErrorMessage="Enter Valid Email Id" Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"></asp:RegularExpressionValidator>
    <br />
<label>City:</label><br />
<input class='input' type='text' name='dcity' id='dcity' runat="server"/>
  </br>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"  ErrorMessage="Enter City" ControlToValidate="dcity" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="requiredfieldclass" ID="RegularExpressionValidator1" runat="server" ControlToValidate="dcity" ErrorMessage="Aphabet only" Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
    <br />
<input class='submit' type='submit' name='submit' value='update' runat="server" onserverclick="Button1_Click"/>
            </div>
        </div>
</asp:Content>
