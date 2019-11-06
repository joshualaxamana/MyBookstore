using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Publishers_Add : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"INSERT INTO publishers VALUES (@pubName)";
        cmd.Parameters.AddWithValue("@pubName", txtPub.Text);
        cmd.ExecuteNonQuery();
        con.Close();

        Response.Redirect("Default.aspx");
        
    }
}