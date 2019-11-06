using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Authors_Details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null) // user selected a record
        {
            int authorID = 0; // initial value
            bool validAuthor = int.TryParse(Request.QueryString["ID"].ToString(),
                                    out authorID);
            
            if (validAuthor)
            {
                if (!IsPostBack)
                {
                    GetInfo(authorID);
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            
        }
        else // user did not select a record
        {
            Response.Redirect("Default.aspx");
        }
    }

    void GetInfo(int ID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT authorFN, authorLN, authorPhone,
            authorAddress, authorCity, authorState, authorZip
            FROM authors WHERE authorID=@authorID";
        cmd.Parameters.AddWithValue("@authorID", ID);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtFN.Text = dr["authorFN"].ToString();
                txtLN.Text = dr["authorLN"].ToString();
                txtPhone.Text = dr["authorPhone"].ToString();
                txtAddress.Text = dr["authorAddress"].ToString();
                txtCity.Text = dr["authorCity"].ToString();
                txtState.Text = dr["authorState"].ToString();
                txtZip.Text = dr["authorZip"].ToString();
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
        cmd.CommandText = @"UPDATE authors SET 
                authorFN=@authorFN, authorLN=@authorLN, authorPhone=@authorPhone,
                authorAddress=@authorAddress,authorCity=@authorCity, authorState=@authorState,
                authorZip=@authorZip WHERE authorID=@authorID";
        cmd.Parameters.AddWithValue("@authorFN", txtFN.Text);
        cmd.Parameters.AddWithValue("@authorLN", txtLN.Text);
        cmd.Parameters.AddWithValue("@authorPhone", txtPhone.Text);
        cmd.Parameters.AddWithValue("@authorAddress", txtAddress.Text);
        cmd.Parameters.AddWithValue("@authorCity", txtCity.Text);
        cmd.Parameters.AddWithValue("@authorState", txtState.Text);
        cmd.Parameters.AddWithValue("@authorZip", txtZip.Text);
        cmd.Parameters.AddWithValue("@authorID", Request.QueryString["ID"].ToString());
        cmd.ExecuteNonQuery();
        con.Close();

        Response.Redirect("Default.aspx");

        

    }
}