using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Authors_Add : System.Web.UI.Page
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
        cmd.CommandText = @"INSERT INTO authors VALUES (@authorLN, @authorFN, @authorPhone, @authorAddress, @authorCity, @authorState, @authorZip)";
        cmd.Parameters.AddWithValue("@authorFN", txtFN.Text);
        cmd.Parameters.AddWithValue("@authorLN", txtLN.Text);
        cmd.Parameters.AddWithValue("@authorPhone", txtPhone.Text);
        cmd.Parameters.AddWithValue("@authorAddress", txtAddress.Text);
        cmd.Parameters.AddWithValue("@authorCity", txtCity.Text);
        cmd.Parameters.AddWithValue("@authorState", txtState.Text);
        cmd.Parameters.AddWithValue("@authorZip", txtZip.Text);
        cmd.ExecuteNonQuery();
        con.Close();

        Response.Redirect("Default.aspx");

        

    }
}