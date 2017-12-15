<%@ Page Title="" Language="C#" MasterPageFile="~/Music.Master" AutoEventWireup="true" CodeBehind="Tracks.aspx.cs" Inherits="ProjectDB.Tracks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            padding-top:50px;
        }
        .auto-style2 {
            width: 347px;
            padding-top:50px;
        }
        .auto-style3 {
            width: 337px;
            padding-top:50px;
        }
        .auto-style4 {
            width: 347px;
            height: 31px;
            padding-top:50px;
        }
        .auto-style5 {
            width: 337px;
            height: 31px;
            padding-top:50px;
        }
        .auto-style6 {
            height: 31px;
            padding-top:50px;
        }
        .auto-style7 {
            width: 337px;
            text-align: center;
            padding-top:50px;
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

  .submit-class-gray {
    color: #fff;
    border-radius: 3px;
    background: gray;
    padding: 5px;
    margin-top: 40px;
    border: none;
    min-width: 100px;
    height: 30px;
    box-shadow: 0 0 1px 2px #123456;
    font-size: 16px;
     cursor: pointer;
}

  .submit-class{
color:#fff;
border-radius:3px;
background:#1F8DD6;
padding:5px;
margin-top:40px;
border:none;
width:350px;
height:30px;
box-shadow:0 0 1px 2px #123456;
font-size:16px;
cursor: pointer;
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
   .iframecss{
       padding:45px;
       padding-left:310px;
       width:100%;
       left: 50%;
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
     <script type="text/javascript">
         function playSound(el, soundfile) {
             var embed = document.getElementById("embed");
             if (!embed) {
                 document.getElementById("playButton").innerText = "Pause";
                 var embed = document.createElement("embed");
                 embed.id = "embed";
                 embed.setAttribute("src", soundfile);
                 embed.setAttribute("hidden", "true");
                 el.appendChild(embed);
             } else {
                 document.getElementById("playButton").innerText = "Play";
                 embed.parentNode.removeChild(embed);
             }

         }
      </script>
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
         <div style="position: absolute; top:100px; z-index:-1; left:20%; width:100%;">
            <asp:Button ID="Button1" runat="server" Text="Add to the existing Playlist" CssClass="submit-class-gray" OnClick="Button1_Click" CausesValidation="False" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add to the new playlist" CssClass="submit-class-gray" CausesValidation="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button5" runat="server" OnClick="Button5_Click2" Text="PlayButton" CssClass="submit-class-gray" CausesValidation="False" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button4" runat="server" Text="Rate Track" OnClick="Button4_Click" CssClass="submit-class-gray" CausesValidation="False" />
            <asp:Label ID ="Label1" runat ="server"></asp:Label> 
              <asp:Panel ID="Panel4" runat="server" CssClass="iframecss">
              <div id = "DIV5" runat = "server"></div>
             </asp:Panel>
              <asp:Panel ID="Panel3" runat="server" CssClass="submit-class">
           
                  <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Width="333px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:RadioButtonList>
          
                              
                  <asp:Button ID="Button6" runat="server" Text="Submit" CssClass="submit-class" OnClick="Button6_Click" />
              </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Height="289px">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">PlayList Title</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox1" runat="server" Width="330px" CssClass="searchTerm"></asp:TextBox>
                        </td>
                        <td>
                            <br />
                           <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Only Alphabets" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                           --%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Only Alphabetnumeric" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9\s,]*$"></asp:RegularExpressionValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Title" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">PlayList Type</td>
                        <td class="auto-style5">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="333px">
                                <asp:ListItem>Public</asp:ListItem>
                                <asp:ListItem>Private</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="auto-style6">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Select one value" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style7">
                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Create" Width="155px" CssClass="submit-class" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
     
        <div id ="DIV" runat ="server">
            <asp:Panel ID="Panel2" runat="server" style="padding-top:10px; width:100px;height:35px">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataTextField="playlisttitle" DataValueField="playlistid" AppendDataBoundItems="true" class="submit-class-gray" >
             
                    </asp:DropDownList>
                <br />
                <br />
            </asp:Panel>
        </div>
                </div>
  </asp:Content>
