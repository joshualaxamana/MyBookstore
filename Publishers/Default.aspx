<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Publishers_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Publishers</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
</head>
<body>
     <div class="container">
        <div class="col-lg-12">
            <form runat="server" class="form-horizontal">
                <h1 class="text-center">View Publishers</h1>
                <table class="table table-hover">
                    <thead>
                        <th>#</th>
                        <th>Publisher Name</th>
                        <th></th>
                    </thead>
                    <tbody>
                        <asp:ListView ID="lvPub" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("pubID")%></td>
                                    <td><%# Eval("pubName")%></td>
                                    <td></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="5">
                                        <h2 class="text-center">No records found.</h2>
                                    </td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </form>
        </div>
    </div>
</body>
</html>
