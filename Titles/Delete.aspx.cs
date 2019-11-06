using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Titles_Delete : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetConnection());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            int authorID = 0;
            bool validAuthor = int.TryParse(Request.QueryString["ID"].ToString(), out authorID);

            if (validAuthor)
            {
                if (!IsPostBack)
                {
                    DeleteRecord(int.Parse(Request.QueryString["ID"].ToString()));
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

    void DeleteRecord(int ID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"DELETE FROM titles WHERE titleID=@titleID";
        cmd.Parameters.AddWithValue("@titleID", ID);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Default.aspx");
    }
}