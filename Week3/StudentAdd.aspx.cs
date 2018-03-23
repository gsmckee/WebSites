using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

public partial class StudentAdd : System.Web.UI.Page
{
    MySqlConnection conn;
    string connStr;
    Exception ex;
    bool m_connOpen;
    string fName, lName;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = (string)Session["MySqlConnection"];
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (conn = new MySqlConnection(connStr))
        {
            conn.Open();
            //Response.Write("Hello World");
            if (conn.State == System.Data.ConnectionState.Open)
            {
                fName = tbF_name.Text;
                lName = tbL_name.Text;
                string tblSearch = @"select * from Students where firstName = '" + fName + "' and lastName= '" + lName + "';";
                
                try
                {
                    MySqlCommand comm = new MySqlCommand(tblSearch, conn);
                    MySqlDataReader rdr = comm.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (!rdr.Read().Equals(fName) && !rdr.Read().Equals(lName))
                        {
                            String query = @"insert into Students (firstName, lastName) values('" + fName + "', '" + lName + "');";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            try
                            {
                                cmd.ExecuteNonQuery();
                                Response.Redirect("Default.aspx");
                            }
                            catch (Exception ex)
                            {
                                string error = ex.Message;
                                Session["LastError"] = error;
                                Response.Redirect("Error.aspx");
                                return;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                        else
                        {
                            Response.Write("A student by the name of " + fName + " " + lName + " already exists.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    Session["LastError"] = error;
                    Response.Redirect("Error.aspx");
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Response.Write("Connection Failed!");
                Response.Write(conn.State.ToString() + "</br>");
            }
        }
        
    }
}