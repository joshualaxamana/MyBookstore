<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Authors_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Authors</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="col-lg-12">
            <form runat="server" class="form-horizontal">
                <h1 class="text-center"><i class="fa fa-eye"></i> View Authors</h1>
                <div class="col-lg-offset-6">
                    <div class="input-group">
                        <asp:TextBox ID="txtKeyword" runat="server"
                            class="form-control" placeholder="Search Authors" />
                        <span class="input-group-btn">
                            <asp:LinkButton ID="btnSearch" runat="server"
                                class="btn btn-info" OnClick="btnSearch_Click">
                                <i class="fa fa-search"></i>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
                <table class="table table-hover">
                    <thead>
                        <th>#</th>
                        <th>Author Name</th>
                        <th>Phone</th>
                        <th>Address</th>
                        <th></th>
                    </thead>
                    <tbody>
                        <asp:ListView ID="lvAuthors" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("authorID")%></td>
                                    <td><%# Eval("authorName")%></td>
                                    <td><%# Eval("authorPhone")%></td>
                                    <td><%# Eval("authorAddress")%></td>
                                    <td>
                                        <a href='Details.aspx?ID=<%# Eval("authorID") %>' 
                                            class="btn btn-xs btn-success">
                                            <i class="fa fa-edit"></i>
                                        </a>
                                        <a href='Delete.aspx?ID=<%# Eval("authorID") %>' 
                                            class="btn btn-xs btn-danger" onclick='return confirm("Are you sure?");'>
                                            <i class="fa fa-trash-o"></i>
                                        </a>
                                    </td>
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
