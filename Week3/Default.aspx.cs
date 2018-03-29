using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

public partial class _Default : System.Web.UI.Page
{
    MySqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        String connString = "Database = OurBoard; Data Source = localhost; Uid = root; SslMode = none;";
        conn = new MySqlConnection(connString);
        try
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                Response.Write("Connection established.");
                String query = "SELECT * from Students;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
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
                Session["MySqlConnection"] = connString;

            }
            else
            {
                Response.Write("Connection Failed!");
                Response.Write(conn.State.ToString() + "</br>");
            }
        }
        catch (Exception ex)
        {
            string error = ex.Message;
            Session["LastError"] = error;
            Response.Redirect("Error.aspx");
            //Response.Write("Connection failed to be established.");
        }
       
        finally
        {
            conn.Close();
        }
        //Response.Write("Hello World");
    }


    protected void addStud_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentAdd.aspx");
    }



    protected void dropStud_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentDrop.aspx");
    }

    protected void fullProfile_Click(object sender, EventArgs e)
    {
        string connString = (String)Session["MySqlConnection"];
        conn = new MySqlConnection(connString);
        try
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                String query = "select * from students left join gpa on students.student_id = gpa.student_id;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Response.Write( "<table>"+ "<tr>" + "<th>ID</th> <th>Course</th> <th>First</th> <th>Last</th> <th>GPA</th>" + "</tr>");
                while (rdr.Read())
                {
                    String sID = rdr["student_id"].ToString();
                    String fName = rdr["firstName"].ToString();
                    String lName = rdr["lastName"].ToString();
                    String courseNum = rdr["course_num"].ToString();
                    String gpa = rdr["gpa"].ToString();

                    String entry = "<tr>" + "<td>" + sID + "</td>";
                    entry += "<td>" + courseNum + "</td>";
                    entry += "<td>" + fName + "</td>" + "<td>" + lName + "</td>";
                    entry+= "<td>" + gpa + "</td>" + "</tr>";
                    Response.Write(entry);
                }
                Response.Write("</table>");

            }
            else
            {
                Response.Write("Connection Failed!");
                Response.Write(conn.State.ToString() + "</br>");
            }
        }
        catch (Exception ex)
        {
            string error = ex.Message;
            Session["LastError"] = error;
            Response.Redirect("Error.aspx");
            //Response.Write("Connection failed to be established.");
        }

        finally
        {
            conn.Close();
        }
    }

    protected void addCourse_Click(object sender, EventArgs e)
    {

    }

    protected void changeStud_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateEntry.aspx");
    }
}