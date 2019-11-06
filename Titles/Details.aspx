<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Titles_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit a Book Title</title>
    <link rel ="stylesheet" href="../css/bootstrap.css" />
</head>
<body>
    <div class="container">
        <div class="col-lg-12">
            <h1 class="text-center">Book Title #<asp:Literal ID="ltID" runat="server" /> Details</h1>
            <div class="clearfix well">
                <form runat="server" class="form-horizontal">
                   <div class="col-lg-6">
                       <div class="form-group">
                           <label class="control-label col-lg-4">Publisher</label>
                           <div class="col-lg-8">
                               <asp:DropDownList ID="ddlPublishers" runat="server" CssClass="form-control" required />
                           </div>
                       </div>
                       <div class="form-group">
                           <label class="control-label col-lg-4">Author</label>
                           <div class="col-lg-8">
                               <asp:DropDownList ID="ddlAuthors" runat="server" CssClass="form-control" required />
                           </div>
                       </div>
                       <div class="form-group">
                           <label class="control-label col-lg-4">Title Name</label>
                           <div class="col-lg-8">
                               <asp:TextBox ID="txtName" runat="server" Class="form-control" maxlength="80" required />
                           </div>
                       </div>
                       <div class="form-group">
                           <label class="control-label col-lg-4">Price</label>
                           <div class="col-lg-8">
                               <asp:TextBox ID="txtPrice" runat="server" Class="form-control" type="number" step="0.01" min="0.0" max="9999.99" text="0.01" required />
                           </div>
                       </div>
                   </div>

                   <div class="col-lg-6">
                       <div class="form-group">
                           <label class="control-label col-lg-4">Publication Date</label>
                           <div class="col-lg-8">
                               <asp:Textbox ID="txtDate" runat="server" CssClass="form-control" type="date" required />
                           </div>
                       </div>
                       <div class="form-group">
                           <label class="control-label col-lg-4">Notes</label>
                           <div class="col-lg-8">
                               <asp:Textbox ID="txtNotes" runat="server" CssClass="form-control" textmode="MultiLine" Rows="3" required />
                           </div>
                       </div>
                       <div class="form-group">
                        <div  class="col-lg-offset-4 col-lg-6">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-warning btn-block" Text="Update"
                              onclick="btnUpdate_Click" />
                            <a href="Default.aspx" class="btn btn-default btn-block">Back</a>
                        </div>
                       </div>
                   </div>
                </form>
            </div>
        </div>  
    </div>
    
</body>
</html>
