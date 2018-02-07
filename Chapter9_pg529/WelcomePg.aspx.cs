using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WelcomePg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        if(Request.Cookies["userInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblWelcome.Text = lblWelcome.Text + ", " + Request.Cookies["userInfo"]["userName"].ToString();
            lblVisits.Text = lblVisits.Text + Request.Cookies["userInfo"]["lastVisit"].ToString();
        }
    }
}