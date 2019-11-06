<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Titles_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a Book title</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
</head>
<body>
   <div class="container">
       <div class="col-lg-12">
           <h1 class="text-center">Add a Book Title</h1>
           
               <form runat="server" class="form-horizontal clearfix well">
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
                           <div class="col-lg-offset-4 col-lg-6">
                               <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add" onclick="btnAdd_Click"/>
                           </div>
                       </div>
                   </div>
               </form>
               
           
       </div>
   </div>
</body>
</html>
