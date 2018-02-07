using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //public HttpCookieCollection users
    //{
    //    get
    //    {
    //        string userName = userInfo.Values["userName"];
    //        return userName;
    //    }
    //}
    public HttpCookie userInfo = new HttpCookie("userInfo");
    public int nag = 0; 
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie userInfo = Request.Cookies["userInfo"];
        if (userInfo == null)
        {
            lblMessage.Text = "Register";
        }
        else { lblMessage.Text = userInfo.Values["lastVisit"]; }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (nag < 4)
        {
            if (userInfo.Values["userName"] != tbUser.ToString())
            {
                if (userInfo.Values["email"] != tbEmail.ToString())
                {
                    userInfo.Values["userName"] = tbUser.ToString();
                    userInfo.Values["email"] = tbEmail.ToString();
                    userInfo.Values["lastVisit"] = DateTime.Now.ToString();
                    userInfo.Expires = DateTime.Now.AddDays(5);
                    userInfo.Path = "/Users";
                    Response.Cookies.Add(userInfo);
                    tbUser.Text = "";
                    tbEmail.Text = "";
                    nag++;
                    Response.Redirect("WelcomePg.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Already registered, last login was " + userInfo.Values["lastVisit"].ToString()
                    + " and expires in: " + userInfo.Expires.ToString();
                tbUser.Text = "";
                tbEmail.Text = "";
                nag++;
            }
        }
        else { userInfo.Expires = DateTime.Now.AddDays(-1); nag = 0; }
    }
}