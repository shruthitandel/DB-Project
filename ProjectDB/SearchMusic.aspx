
<%@ Page Title="" Language="C#" MasterPageFile="~/Music.Master" AutoEventWireup="true" CodeBehind="SearchMusic.aspx.cs" Inherits="ProjectDB.SearchMusic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .message
        {
            color: red;
        }
    </style>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 262px;
            height: 33px;
            color: gray;
            font-size:20px;
        }
        .auto-style3 {
            width: 271px;
            height: 33px;
        }
        .auto-style4 {
            text-align: center;
            width: 271px;
        }
        .auto-style5 {
            height: 33px;
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

 .submit-class {
    color: #fff;
    border-radius: 3px;
    background: #1F8DD6;
    padding: 5px;
    margin-top: 40px;
    border: none;
    width: 100px;
    height: 30px;
    box-shadow: 0 0 1px 2px #123456;
    font-size: 16px;
     cursor: pointer;
}

  .submit-class-gray {
    color: #fff;
    border-radius: 3px;
    background: gray;
    padding: 5px;
    margin-top: 40px;
    border: none;
    width: 100px;
    height: 30px;
    box-shadow: 0 0 1px 2px #123456;
    font-size: 16px;
     cursor: pointer;
}

        .auto-style6 {
            width: 271px;
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
         <div style="position: absolute; top:100px; z-index:-1; left:35%;">
             <h1 class="h1Style" style="text-align: center;"> Search Tracks/Albums/Artist/Playlist</h1>
        <p>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Enter Keyword</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server" Width="377px" onblur="message.style.display='none';" CssClass="searchTerm" onclick="message.style.display='block';"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                       <div id ="message" style="display: none" class="message";>
                           Search by Tracks/Artists/Albums/Plalists
                        </div>
                    </td>
                    <td class="auto-style5">
                       
                        &nbsp;</td>
                    <td class="auto-style5">
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter keyword" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="auto-style6">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" CssClass="submit-class" />
                    </td>
                     

                    <td>
                    </td>
                </tr>
            </table>
        </p>
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="submit-class-gray">Tracks</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="submit-class-gray">Artists</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="submit-class-gray">Albums</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="submit-class-gray">PlayLists</asp:LinkButton>
        </div>
        <p>
            &nbsp;</p>
     <div id ="DIV1" runat ="server">
    </div>
    <div id ="DIV2" runat ="server">
    </div>
    <div id ="DIV3" runat ="server">
    </div>
    <div id ="DIV4" runat ="server">
    </div>
</div>
    </asp:content>
