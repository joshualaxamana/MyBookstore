using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Titles_Add : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPublishers();
            GetAuthors();
        }
    }

    void GetPublishers()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection=con;
        cmd.CommandText = @"SELECT pubID, pubName FROM publishers";
        SqlDataReader data = cmd.ExecuteReader();
        ddlPublishers.DataSource = data;
        ddlPublishers.DataTextField = "pubName";
        ddlPublishers.DataValueField = "pubID";
        ddlPublishers.DataBind();
        con.Close();
        ddlPublishers.Items.Insert(0, new ListItem("Select from the list..."));
    }
    
    void GetAuthors() 
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT authorID, AuthorLN+', '+authorFN AS authorName FROM authors";
        SqlDataReader data = cmd.ExecuteReader();
        ddlAuthors.DataSource = data;
        ddlAuthors.DataTextField = "authorName";
        ddlAuthors.DataValueField = "authorID";
        ddlAuthors.DataBind();
        con.Close();
        ddlAuthors.Items.Insert(0, new ListItem("Select from the list..."));
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"INSERT INTO titles VALUES(@pubID, @authorID, @titleName, @titlePrice, @titlePubDate, @titleNotes)";
        cmd.Parameters.AddWithValue("@pubID", ddlPublishers.SelectedValue);
        cmd.Parameters.AddWithValue("@authorID", ddlAuthors.SelectedValue);
        cmd.Parameters.AddWithValue("@titleName", txtName.Text);
        cmd.Parameters.AddWithValue("@titlePrice", txtPrice.Text);
        cmd.Parameters.AddWithValue("@titlePubDate", txtDate.Text);
        cmd.Parameters.AddWithValue("@titleNotes", txtNotes.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Default.aspx");
        
    }
}