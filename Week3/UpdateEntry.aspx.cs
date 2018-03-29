using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

public partial class UpdateEntry : System.Web.UI.Page
{
    MySqlConnection conn;
    MySqlCommand cmd,cmd2;
    string connStr, query, updateQuery, colName, sID, fName, lName, entry;
    Exception ex;
    bool m_connOpen, updateEntry;

    string search;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = (string)Session["MySqlConnection"];
    }
    protected void studInfo_Click(object sender, EventArgs e)
    {
        using (conn = new MySqlConnection(connStr))
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                Response.Write("Connection established.");
                search = tbSearchTerm.Text;
                query = @"Select * from Students where student_id = '" + search + "' or lastName = '" + search + "';";               
                cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Response.Write("<table>");
                while (rdr.Read())
                {
                    sID = rdr["student_id"].ToString();
                    fName = rdr["firstName"].ToString();
                    lName = rdr["lastName"].ToString();

                    entry = "<tr>" + "<td>" + sID + "</td>";
                    entry += "<td>" + fName + "</td>";
                    entry += "<td>" + lName + "</td>" + "</tr>";
                    Response.Write(entry);
                    ViewState.Add("sID", sID);
                    ViewState.Add("fName", fName);
                    ViewState.Add("lName", lName);
                }
                Response.Write("</table>");
                cblColName.Visible = true;
            }
            else
            {
                Response.Write("Connection Failed!");
                Response.Write(conn.State.ToString() + "</br>");
            }
        }
    }   

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        using (conn = new MySqlConnection(connStr))
        {
            if(tbF_Name.Visible == true && tbL_Name.Visible == true)
            {
                updateQuery = @"update Students set " + cblColName.Items[0].Value + " = '"
                + tbF_Name.Text.ToString() + "', " + cblColName.Items[1].Value + " = '" + tbL_Name.Text.ToString() + " where "
                + cblColName.Items[0].Value + " = '" + ViewState["fName"].ToString() + "' and " + cblColName.Items[1].Value + " = '"
                + ViewState["lName"].ToString() + "';";
            }
            else if(tbF_Name.Visible == true && tbL_Name.Visible == false)
            {
                updateQuery = @"update Students set " + cblColName.Items[0].Value + " = '"
                + tbF_Name.Text.ToString() + "' where " + cblColName.Items[0].Value + " = '" + ViewState["fName"].ToString() + "';";
            }
            else if (tbF_Name.Visible == false && tbL_Name.Visible == true)
            {
                updateQuery = @"update Students set " + cblColName.Items[1].Value + " = '"
                + tbL_Name.Text.ToString() + "' where " + cblColName.Items[1].Value + " = '" + ViewState["lName"].ToString() + "';";
            }
            conn.Open();
            //Response.Write("Hello World");
            if (conn.State == System.Data.ConnectionState.Open)
            {
                if (updateQuery != null)
                {
                    query = @"select * from Students where student_id = " + Convert.ToInt16(ViewState["sID"].ToString()) + ";";
                    cmd2 = new MySqlCommand(updateQuery, conn);
                    cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    Response.Write("<table>");
                    while (rdr.Read())
                    {
                        sID = rdr["student_id"].ToString();
                        fName = rdr["firstName"].ToString();
                        lName = rdr["lastName"].ToString();

                        entry = "<tr>" + "<td>" + sID + "</td>";
                        entry += "<td>" + fName + "</td>";
                        entry += "<td>" + lName + "</td>" + "</tr>";
                        Response.Write(entry);
                    }
                    Response.Write("</table>");
                }
                else
                    Response.Write("You need to provide more information for a alteration of a record");
            }
            else
            {
                Response.Write("Connection Failed!");
                Response.Write(conn.State.ToString() + "</br>");
            }
        }      
    }

    protected void cblColName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cblColName.Items[0].Selected && cblColName.Items[1].Selected)
        {
            tbF_Name.Visible = true;
            tbL_Name.Visible = true;
        }
        else if (cblColName.Items[0].Selected && !cblColName.Items[1].Selected)
        {
            tbF_Name.Visible = true;
            tbL_Name.Visible = false;            
        }
        else if(!cblColName.Items[0].Selected && cblColName.Items[1].Selected)
        {
            tbF_Name.Visible = false;
            tbL_Name.Visible = true;            
        }
    }
}