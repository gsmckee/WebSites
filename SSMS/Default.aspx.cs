using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> userInfo = new List<string>();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlCommand cmd;
        string query = TextBox1.Text;
        SqlConnection conn;
        using (conn = new SqlConnection(connString))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string user = (string)rdr["Username"];
                        TextBox2.Text += user;
                    }
                }
            }
        }
    }
}