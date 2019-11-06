<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
</head>
<body>
   <div class="container">
       <div class="col-lg-offset-3 col-lg-6">
           <h1 class="text-center">User Login</h1>
           <div class="well">
               <form runat="server" class="form-horizontal">
                   <div id="error" runat="server" class="alert alert-danger" visible="false">
                       Invalid Email Address or Password
                   </div>
                   <div class="form-group">
                       <label class="control-label col-lg-4">Email Address</label>
                       <div class="col-lg-8">
                           <asp:TextBox ID="txtEmail" runat="server"
                               CssClass="form-control" />
                       </div>
                   </div>
                   <div class="form-group">
                       <label class="control-label col-lg-4">Password</label>
                       <div class="col-lg-8">
                           <asp:TextBox ID="txtPassword" runat="server"
                               CssClass="form-control" TextMode="Password" />
                       </div>
                   </div>
                   <div class="form-group">
                       <div class="col-lg-offset-4 col-lg-8">
                           <asp:Button ID="btnLogin" runat="server"
                               class="btn btn-success" Text="Login" OnClick="btnLogin_Click" />
                           <a href="Register.aspx" class="btn btn-default">Register</a>
                       </div>
                   </div>
               </form>
           </div>
       </div>
   </div>
</body>
</html>
