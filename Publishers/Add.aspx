<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Publishers_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <title>Add a Publisher</title>
</head>
<body>
    <div class="container">
        <div class="col-lg-offset-3 col-lg-6">
            <h1 class="text-center">Add a Publisher</h1>
            <div class="well">
                <form runat="server" class="form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-lg-4">Publisher Name</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtPub" runat="server" CssClass="form-control" MaxLength="40" required />
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
