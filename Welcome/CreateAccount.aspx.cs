using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CreateAccount : System.Web.UI.Page
{
    // Week 1 Dictionary for storing user profiles.
    //protected Dictionary<string, Profile> profiles;
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
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        btnCreateAcct.Visible = true;
        btnLoginRedirect.Visible = false;
    }
    protected void btnCreateAcct_Click(object sender, EventArgs e)
    {
        string user, pass, first, last, email;
        int age = Convert.ToInt16(tbAge.Text);
        bool admin = cbAdmin.Checked;
        user = tbUser.Text;
        pass = tbPass.Text;
        first = tbFirst.Text;
        last = tbLast.Text;
        email = tbEmail.Text;
        Profile p = new global::Profile(user, pass, first, last, email, age, admin);
        // Week2 unusable class Profile... replace with SQLdb, week3.
        //Profile userProfile = new Profile(pass, first, last, email, age, admin);
        //if (Session["Messina"] == null)
        //{
        // New record in DB.
        //DBRegister userLogin = new DBRegister(user, p); 

        // Dictionary Week2... replace with SQLdb, week3.
        //Dictionary<string, Profile> profiles = (Dictionary<string, Profile>)Session["profiles"];

        if (Messina.CheckIfUserExists(user) == false)
        {

            if (Messina.CheckIfEmailExists(email) == false)
            {

                //profiles.Add(user, userProfile);
                DBRegister userLogin = new DBRegister(p);
                    //Response.Redirect("Home.aspx");
                    btnCreateAcct.Visible = false;
                    btnLoginRedirect.Visible = true;
                    lblMsg.Text = "Successfully created account";

            }
            else
            {
                tbUser.Text = "";
                tbEmail.Text = "";
                tbFirst.Text = "";
                tbLast.Text = "";
                tbPass.Text = "";
                tbConfirmPass.Text = "";
                tbAge.Text = "";
                lblMsg.Text = "Account with that email already exists.";
            }
        }
        else
        {
            tbUser.Text = "";
            lblMsg.Text = "User name in use";
        }
        //}



    }

    protected void btnLoginRedirect_Click(object sender, EventArgs e)
    {
        Session["Messina"] = Session["profiles"];
        Session["profiles"] = null;
        Response.Redirect("Home.aspx");
    }
}