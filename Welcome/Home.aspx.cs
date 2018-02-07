using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
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
        //Session["Messina"] = null; 
        // clear login session when page loads.
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {// (optional) Step B... Event handlers
        string user = tbUser.Text; //grab what was entered in form tbUser.
        string pass = tbPass.Text; //grab what was entered in form tbPass.
                                   //HttpCookie userName = new HttpCookie("Name");

        //if (Session["Messina"] == null)
        //{//type cast data from dictionary object... 
            //this will enable checks against the variables or information properties of an object.
            //Dictionary<string, Profile> profiles =
                //(Dictionary<string, Profile>)Session["profiles"];

            if (Messina.CheckIfUserExists(user) == true)// check if user is stored in dictionary...
            {
                //Profile p = profiles[user];
                if (Messina.CheckForPassMatch(user, pass) == true)// check if password matches the paired user...
                {
                    Messina.DbUserProfile(user, pass);
                    Session["Messina"] = Messina.userProfile;
                    Response.Redirect("Welcome.aspx");
                }
                else
                {
                    tbUser.Text = null;
                    tbPass.Text = null;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Bad Password!";
                }
            }
        //}
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "No such user exists!";
        }

    }

    protected void btnCreateAcct_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateAccount.aspx");
    }
    protected void Page_Render(object sender, EventArgs e)
    {

    }

}