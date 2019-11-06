using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Titles_Details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] !=null)
        {
            int titleID = 0;
            bool validTitle = int.TryParse(Request.QueryString["ID"].ToString(), out titleID);
            if (validTitle)
            {
                if (!IsPostBack)
                {
                    GetID(int.Parse(Request.QueryString["ID"].ToString()));
                }
                if (!IsPostBack)
                {
                    GetAuthors();
                    GetPublishers();
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

       
    }

    void GetPublishers()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
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

    public void GetID(int ID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT titleID, pubID, authorID, titleName, titlePrice, titlePubDate, titleNotes FROM titles WHERE titleID=@titleID";
        cmd.Parameters.AddWithValue(@"titleID", ID);
        SqlDataReader data = cmd.ExecuteReader();
        if (data.HasRows)
        {
            while (data.Read())
            {
                ltID.Text = data["titleID"].ToString();
                ddlPublishers.SelectedValue = data["pubID"].ToString();
                ddlAuthors.SelectedValue = data["authorID"].ToString();
                txtName.Text = data["titleName"].ToString();
                txtPrice.Text = data["titlePrice"].ToString();
                txtDate.Text = data["titlePubDate"].ToString();
                txtNotes.Text = data["titleNotes"].ToString();
            }
            con.Close();
        }
        else
        {
            con.Close();
            Response.Redirect("Default.aspx");
        }
       
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"UPDATE titles SET pubID=@pubID, authorID=@authorID, titleName=@titleName, titlePrice=@titlePrice, titlePubDate=@titlePubDate, titleNotes=@titleNotes WHERE titleID=@titleID";
        cmd.Parameters.AddWithValue("@titleID", ltID.Text);
        cmd.Parameters.AddWithValue("@pubID", ddlPublishers.SelectedValue.ToString());
        cmd.Parameters.AddWithValue("@authorID", ddlAuthors.SelectedValue.ToString());
        cmd.Parameters.AddWithValue("@titleName", txtName.Text);
        cmd.Parameters.AddWithValue("@titlePrice", txtPrice.Text);
        cmd.Parameters.AddWithValue("@titlePubDate", txtDate.Text);
        cmd.Parameters.AddWithValue("@titleNotes", txtNotes.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Default.aspx");
    }
}