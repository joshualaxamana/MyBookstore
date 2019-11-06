using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Authors_Delete : System.Web.UI.Page
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
                    DeleteRecord(authorID);
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

    void DeleteRecord(int ID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"DELETE FROM authors 
            WHERE authorID=@authorID";
        cmd.Parameters.AddWithValue("authorID", ID);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Default.aspx");
    }
}