using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    bool IsExisting(string email)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT userEmail FROM users
                WHERE userEmail=@userEmail";
        cmd.Parameters.AddWithValue("@userEmail", email);
        bool existing = cmd.ExecuteScalar() == null ? false : true;
        con.Close();
        return existing;

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        bool existingEmail = IsExisting(txtEmail.Text);

        if (existingEmail)
        {
            error.Visible = true;
        }
        else
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO users VALUES (@typeID,
                @userEmail, @userPW, @userFN, @userLN, @userPhone,
                @userAddress, @userStatus)";
            cmd.Parameters.AddWithValue("@typeID", 1);
            cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);
            cmd.Parameters.AddWithValue("@userPW", Helper.CreateSHAHash(txtPassword.Text));
            cmd.Parameters.AddWithValue("@userFN", txtFN.Text);
            cmd.Parameters.AddWithValue("@userLN", txtLN.Text);
            cmd.Parameters.AddWithValue("@userPhone", "");
            cmd.Parameters.AddWithValue("@userAddress", "");
            cmd.Parameters.AddWithValue("@userStatus", "Pending");
            cmd.ExecuteNonQuery();
            con.Close();
            string url = Helper.GetURL() + "ActivateUser.aspx?email=" +
                txtEmail.Text + "&pw=" + Helper.CreateSHAHash(txtPassword.Text);

            string message = "Hello, " + txtFN.Text + " " + txtLN.Text + "!<br/>" +
                    "Thank you for creating an account with us.<br/><br/>" +
                    "Please click the link below to activate your account: <br/>" +
                    "<a href='" + url + "'>" + url + "</a><br/><br/>" +
                    "Regards," +
                    "The Administrator";

            Helper.SendEmail(txtEmail.Text, "User Registration", message);

            Response.Redirect("Login.aspx");
        }
    }
}