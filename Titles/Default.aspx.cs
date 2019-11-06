using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Titles_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTitles();
        }
    }

    void GetTitles()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT t.titleID, p.pubName, 
            a.authorLN + ', ' + a.authorFN AS authorName,
            t.titleName, t.titlePrice, t.titlePubDate,
            t.titleNotes FROM titles t 
            INNER JOIN publishers p ON t.pubID = p.pubID 
            INNER JOIN authors a ON t.authorID = a.authorID";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "titles");

        lvTitles.DataSource = ds;
        lvTitles.DataBind();
        con.Close();
    }

    void GetTitles(string keyword)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT t.titleID, p.pubName, 
            a.authorLN + ', ' + a.authorFN AS authorName,
            t.titleName, t.titlePrice, t.titlePubDate,
            t.titleNotes FROM titles t 
            INNER JOIN publishers p ON t.pubID = p.pubID 
            INNER JOIN authors a ON t.authorID = a.authorID
            WHERE t.titleID LIKE @keyword OR
            p.pubName LIKE @keyword OR
            a.authorLN LIKE @keyword OR
            a.authorFN LIKE @keyword OR
            t.titleName LIKE @keyword OR
            t.titleNotes LIKE @keyword";
        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "authors");

        lvTitles.DataSource = ds;
        lvTitles.DataBind();
        con.Close();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetTitles(txtKeyword.Text);
    }
}