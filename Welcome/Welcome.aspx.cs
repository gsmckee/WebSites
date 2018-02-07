using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Welcome : System.Web.UI.Page
{
    public DBRegister Messina
    {
        get
        {
            if (Session["Messina"] == null)
            {
                Session["Messina"] = new DBRegister();
            }
            return (DBRegister)Session["Messina"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {//Step A

        Profile p = (Profile)Session["Messina"];
        lblWelcome.Text = "Welcome, " + p.First;
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {// (optional) Step B... Event handlers
        Session["Messina"] = null; // remove credential from session variable
    }

    protected void btnUserList_Click(object sender, EventArgs e)
    {
        Response.Redirect("HowToReadFromDB.aspx");
    }
    protected void Page_Render(object sender, EventArgs e)
    {
        if (Session["Messina"] == null)
        {
            Response.Redirect("Home.aspx");// redirects to login page if session variable is empty
        }
        else
        {
            Profile p = (Profile)Session["Messina"];
            lblWelcome.Text = "Welcome, " + p.First + " " + p.Last;
        }
    }

}