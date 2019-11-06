<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Authors_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add an Author</title>
    <link rel="stylesheet" href="../css/bootstrap.css" />
</head>
<body>
    <div class="container">
        <div class="col-lg-offset-3 col-lg-6">
            <h1 class="text-center">Add an Author</h1>
            <div class="well">
                <form runat="server" class="form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-lg-4">First Name</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtFN" runat="server" CssClass="form-control" MaxLength="40" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Last Name</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtLN" runat="server" CssClass="form-control" MaxLength="20" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Phone</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" MaxLength="12" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Address</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" MaxLength="40" TextMode="MultiLine" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">City</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" MaxLength="20" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">State</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtState" runat="server" CssClass="form-control" MaxLength="2" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-4">Zip</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" MaxLength="5" required />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-offset-4 col-lg-8">
                            <asp:Button ID="btnAdd" runat="server" 
                                CssClass="btn btn-danger btn-lg" Text="Add" OnClick="btnAdd_Click"/>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
