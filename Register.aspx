<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="col-lg-offset-3 col-lg-6">
            <h1 class="text-center">User Registration</h1>
            <div class="well">
                <form runat="server" class="form-horizontal">
                    <div id="error" runat="server" class="alert alert-danger" visible="false">
                        Email Address already taken.
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Email Address</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtEmail" runat="server"
                                CssClass="form-control" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Password</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtPassword" runat="server"
                                CssClass="form-control" TextMode="Password" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Repeat Password</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtRPassword" runat="server"
                                CssClass="form-control" TextMode="Password" required />
                            <asp:CompareValidator ID="cv_Password" runat="server"
                                ControlToValidate="txtRPassword" ControlToCompare="txtPassword"
                                SetFocusOnError="true" Display="Dynamic"
                                ErrorMessage="Password Does Not Match" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">First Name</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtFN" runat="server"
                                CssClass="form-control text-capitalize" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Last Name</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtLN" runat="server"
                                CssClass="form-control text-capitalize" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-4 col-lg-8">
                            <asp:Button ID="btnRegister" runat="server"
                                CssClass="btn btn-success" Text="Register" OnClick="btnRegister_Click" />
                            <a href="Login.aspx" class="btn btn-default">
                                Login
                            </a>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
