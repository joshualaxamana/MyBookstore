using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Authors_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAuthors();
        }
    }

    void GetAuthors()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT authorID, authorLN + ', ' +
                authorFN AS authorName, authorPhone, authorAddress + ', ' +
                authorCity + ', ' + authorState + ', ' + authorZip AS authorAddress
                FROM authors";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "authors");

        lvAuthors.DataSource = ds;
        lvAuthors.DataBind();
        con.Close();
    }

    void GetAuthors(string keyword)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT authorID, authorLN + ', ' +
                authorFN AS authorName, authorPhone, authorAddress + ', ' +
                authorCity + ', ' + authorState + ', ' + authorZip AS authorAddress
                FROM authors WHERE authorID LIKE @keyword OR
                authorLN LIKE @keyword OR 
                authorFN LIKE @keyword OR
                authorPhone LIKE @keyword OR
                authorAddress LIKE @keyword OR
                authorCity LIKE @keyword OR
                authorState LIKE @keyword OR
                authorZip LIKE @keyword";
        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "authors");

        lvAuthors.DataSource = ds;
        lvAuthors.DataBind();
        con.Close();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetAuthors(txtKeyword.Text);
    }
}