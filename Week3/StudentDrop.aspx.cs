using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

public partial class StudentDrop : System.Web.UI.Page
{
    MySqlConnection conn;
    string connStr;
    Exception ex;
    bool m_connOpen;
    string f_Name, l_Name;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = (string)Session["MySqlConnection"];
    }

    protected void btnDropStud_Click(object sender, EventArgs e)
    {
        using (conn = new MySqlConnection(connStr))
        {
            conn.Open();
            //Response.Write("Hello World");
            if (conn.State == System.Data.ConnectionState.Open)
            {
                btnDropStud.Visible = false;
                Response.Write("Connection established.");
                f_Name = tbF_name.Text;
                l_Name = tbL_name.Text;
                String query = @"delete from Students where firstName = '" + f_Name + "' and lastName = '" + l_Name + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception err)
                {
                    string error = err.Message;
                    Session["LastError"] = error;
                    Response.Redirect("Error.aspx");
                    return;
                }
                String query2 = "SELECT * from Students;";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                MySqlDataReader rdr = cmd2.ExecuteReader();
                Response.Write("<table>");
                while (rdr.Read())
                {
                    String sID = rdr["student_id"].ToString();
                    String fName = rdr["firstName"].ToString();
                    String lName = rdr["lastName"].ToString();

                    String entry = "<tr>" + "<td>" + sID + "</td>";
                    entry += "<td>" + fName + "</td>";
                    entry += "<td>" + lName + "</td>" + "</tr>";
                    Response.Write(entry);
                }
                Response.Write("</table>");
                lblF_Name.Visible = false; lblL_Name.Visible = false; tbF_name.Visible = false; tbL_name.Visible = false;
                btnHome.Visible = true;
                btnAddStud.Visible = true;

            }
            else
            {
                Response.Write("Connection Failed!");
                Response.Write(conn.State.ToString() + "</br>");
            }
        }

    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btnAddStud_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentAdd.aspx");
    }
}