<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="ProjectDB.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="assets/header-user-dropdown.css"/>
	<link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type="text/css"/>
    <script  type="text/javascript">
        function validate() {
            var a = document.getElementById("<%=TextBox4.ClientID%>").value
            var b = document.getElementById("<%=TextBox5.ClientID%>").value
            if (a != b) {
                alert("Password and Confirm Password does not match ");
                document.getElementById("<%=TextBox5.ClientID%>").focus();
                return false;
            }
        }
    </script>
    <title></title>
    <style type="text/css">
        

        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

        .login-page {
            width: 650px;
            padding: 8% 0 0;
            margin: auto;
        }
.form {
  position: absolute;
  z-index: -1;
  background: #FFFFFF;
  max-width: 750px;
  margin: 0 auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.form input {
  font-family: "Roboto", sans-serif;
  outline: 0;
  background: #f2f2f2;
  width: 150%;
  border: 0;
  margin: 0 0 15px;
  padding: 15px;
  box-sizing: border-box;
  font-size: 14px;
}


.form .button-style {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background: #4CAF50;
  width: 100%;
  border: 0;
  padding: 15px;
  color: #FFFFFF;
  font-size: 14px;
  -webkit-transition: all 0.3 ease;
  transition: all 0.3 ease;
  cursor: pointer;
}
.button-style:hover,.button-style:active,.button-style:focus {
  background: #43A047;
}
.form .message {
  margin: 15px 0 0;
  color: #b3b3b3;
  font-size: 12px;
}
.form .message a {
  color: #4CAF50;
  text-decoration: none;
}
.form .register-form {
  display: none;
}
.container {
  position: relative;
  z-index: 1;
  max-width: 300px;
  margin: 0 auto;
}
.container:before, .container:after {
  content: "";
  display: block;
  clear: both;
}
.container .info {
  margin: 50px auto;
  text-align: center;
}
.container .info h1 {
  margin: 0 0 15px;
  padding: 0;
  font-size: 36px;
  font-weight: 300;
  color: #1a1a1a;
}
.container .info span {
  color: #4d4d4d;
  font-size: 12px;
}
.container .info span a {
  color: #000000;
  text-decoration: none;
}
.container .info span .fa {
  color: #EF3B3A;
}
body {
  background: #4d4d4d; /* fallback for old browsers */
  background: -webkit-linear-gradient(right, #4d4d4d, #4d4d4d);
  background: -moz-linear-gradient(right, #4d4d4d, #4d4d4d);
  background: -o-linear-gradient(right, #4d4d4d, #4d4d4d);
  background: linear-gradient(to left, #4d4d4d, #4d4d4d);
  font-family: "Roboto", sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;      
}
.requiredfieldclass{
    padding-left:95px;
}
.valerror{
    display:inline;
}
    </style>
</head>
<body>

        <header class="header-user-dropdown" style="left:0">

	<div class="header-limiter">
		<h1><a href="/Home.aspx">Akriti-Shruthi<span> Music Company</span></a></h1>

	<!--	<nav>
			<a href="#">Overview</a>
			<a href="#">Surveys</a>
			<a href="#">Reports</a>
			<a href="#">Roles <span class="header-new-feature">new</span></a>
		</nav> -->

       
	
	</div>

</header>
    <div>
     <div class="login-page">
        <div class="form">
    <form id="form1" runat="server">
        <div>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Create a User Profile<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">NAME</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="50" ></asp:TextBox>
                    </td>
                    <td>
                        </td>
                   <td>
                       <asp:RequiredFieldValidator CssClass="requiredfieldclass" ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Name" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator CssClass="requiredfieldclass" ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Aphabet only" Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                     </td>  
                     
                </tr>
                <tr>
                    <td class="auto-style3">EMAIL ID</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                    <td>
                     </td>
                     <td>  
                        <asp:RequiredFieldValidator CssClass="requiredfieldclass" ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Email ID" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator CssClass="requiredfieldclass" ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Valid Email Id" Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"></asp:RegularExpressionValidator>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style3">USERNAME</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox3" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                     <td>
                        </td>
                     <td>
                       
                        <asp:RequiredFieldValidator CssClass="requiredfieldclass" ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Enter Username" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator CssClass="requiredfieldclass" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Only Alphabets or numbers" ControlToValidate="TextBox3" Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
                    </td>
                    
                  
                  
                </tr>
                <tr>
                    <td class="auto-style3">PASSWORD</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" MaxLength="50" ></asp:TextBox>
                    </td>
                    <td>
                    </td>
                     <td>
                       
                        <asp:RequiredFieldValidator CssClass="requiredfieldclass" ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Enter Password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style3">CONFIRM PASSWORD</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" MaxLength="50" ></asp:TextBox>
                    </td>
                    <td>
                        </td>
                     <td>
                       
                        <asp:RequiredFieldValidator CssClass="requiredfieldclass" ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="Enter Confirm Password" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                    </td>
                  
                </tr>
                <tr>
                    <td class="auto-style4">CITY</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox6" runat="server" MaxLength="50" ></asp:TextBox>
                    </td>
                    <td>
                        </td>
                     <td>
                       
                        <asp:RequiredFieldValidator CssClass="requiredfieldclass" ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="TextBox6" ErrorMessage="Enter City" ForeColor="Red"></asp:RequiredFieldValidator>
                                 
                        <asp:RegularExpressionValidator CssClass="requiredfieldclass" ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ErrorMessage="Only Alphabets" ControlToValidate="TextBox6" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                    </td>
                  
                </tr>
            </table>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Submit" Width="196px" CssClass="button-style"  OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <br />
&nbsp;</div>
    </form>
            </div></div></div>
</body>
</html>
