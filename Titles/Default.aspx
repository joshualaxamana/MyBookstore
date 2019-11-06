<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Titles_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Book Titles</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="col-lg-12">
            <form runat="server" class="form-horizontal">
                <h1 class="text-center"><i class="fa fa-facebook-official"></i>  View Book Titles</h1>
                <div class="col-lg-offset-8">
                    <div class="input-group">
                        <asp:TextBox ID="txtKeyword" runat="server"
                            class="form-control" placeholder="Keyword..." />
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
                        <th class="hidden-xs hidden-sm hidden-md">Publisher</th>
                        <th class="hidden-xs hidden-sm hidden-md">Author Name</th>
                        <th>Title Name</th>
                        <th>Price</th>
                        <th class="hidden-xs hidden-sm hidden-md">Publication Date</th>
                        <th class="hidden-xs hidden-sm hidden-md">Notes</th>
                        <th></th>
                    </thead>
                    <tbody>
                        <asp:ListView ID="lvTitles" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("titleID") %></td>
                                    <td class="hidden-xs hidden-sm hidden-md"><%# Eval("pubName") %></td>
                                    <td class="hidden-xs hidden-sm hidden-md"><%# Eval("authorName") %></td>
                                    <td><%# Eval("titleName") %></td>
                                    <td><%# Eval("titlePrice", "{0: #,###,##0.00}") %></td>
                                    <td class="hidden-xs hidden-sm hidden-md"><%# Eval("titlePubDate", "{0: MM/dd/yyyy}") %></td>
                                    <td class="hidden-xs hidden-sm hidden-md"><%# Eval("titleNotes") %></td>
                                    <td>
                                        <a href='Details.aspx?ID=<%# Eval("titleID") %>' 
                                            class="btn btn-xs btn-success">
                                            <i class="fa fa-edit"></i>
                                        </a>
                                        <a href='Delete.aspx?ID=<%# Eval("titleID") %>' 
                                            class="btn btn-xs btn-danger" onclick='return confirm("Are you sure?");'>
                                            <i class="fa fa-trash-o"></i>
                                        </a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="8">
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