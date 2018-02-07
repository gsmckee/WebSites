using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HowToReadFromDB : System.Web.UI.Page
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
    {
        List<Profile> allUsers = Messina.GetAllUsers();
        foreach(Profile user in allUsers)
        {
            Response.Write(user + "<br />");
        }
    }
        
    protected void Page_Render(object sender, EventArgs e)
    {

    }
}