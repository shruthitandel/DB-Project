<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectDB.Login" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<link rel="stylesheet" href="assets/header-user-dropdown.css">
	<link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type='text/css'>
    <title></title>
<script>

</script>
    <style type="text/css">
        .auto-style5 {
            margin-left: 0px;
            margin-bottom: 0px;
        }
        .auto-style6 {
            width: 81%;
            margin-left: 254px;
        }
        .auto-style7 {
            height: 2px;
        }
        .auto-style8 {
            width: 223px;
            height: 33px;
        }
        .auto-style9 {
            height: 2px;
            width: 223px;
        }
        .auto-style10 {
            width: 187px;
            height: 33px;
        }
        .auto-style11 {
            height: 2px;
            width: 187px;
        }
        .auto-style12 {
            height: 33px;
        }
        .auto-style13 {
            width: 223px;
        }

        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

.login-page {
  width: 360px;
  padding: 8% 0 0;
  margin: auto;
}
.form {
  position: relative;
  z-index: 1;
  background: #FFFFFF;
  max-width: 360px;
  margin: 0 auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.form input {
  font-family: "Roboto", sans-serif;
  outline: 0;
  background: #f2f2f2;
  width: 100%;
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
       <form id="form1" runat="server" class="login-form">
      
      <input type="text" id="TextBox1" runat="server" placeholder="username"/>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"  ErrorMessage="Alphabets or numbers only" ControlToValidate="TextBox1" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ErrorMessage="Enter Username" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>           
      <input type="password" id="TextBox2" runat="server" placeholder="password"/>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"  ErrorMessage="Enter Password" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
      <asp:Button id="Button1" runat="server" CssClass="button-style" Text="Login" OnClick="Button1_Click"/>
      <p class="message">Not registered? <a href="/signup.aspx">Create an account</a></p>
          
    </form>
  </div>
            </div>
        </div>
    
</body>
</html>




   
   
  
