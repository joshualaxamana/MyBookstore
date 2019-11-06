using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT userID, typeID FROM users
            WHERE userEmail=@userEmail AND userPW=@userPW";
        cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);
        cmd.Parameters.AddWithValue("@userPW", Helper.CreateSHAHash(txtPassword.Text));
        SqlDataReader data = cmd.ExecuteReader();
        if (data.HasRows) // email and password match
        {
            while(data.Read())
            {
                Session["userID"] = data["userID"].ToString();
                Session["typeID"] = data["typeID"].ToString();
            }
            con.Close();
            Response.Redirect("Default.aspx");
        }
        else // email and password don't match
        {
            con.Close();
            error.Visible = true;
        }

    }
}