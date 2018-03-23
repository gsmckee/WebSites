﻿using System;
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
    bool m_connOpen;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_connOpen = false;
        String connString = "Database = OurBoard; Data Source = localhost; Uid = root; SslMode = none;";
        conn = new MySqlConnection(connString);
        try
        {
            conn.Open();
            m_connOpen = true;
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
}