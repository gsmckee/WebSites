using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class NFL : System.Web.UI.Page
{
    protected string teamSelected = "";
    protected Keymaker Messina
    {
        get
        {
            if (Session["Messina"] == null)
            {
                Session["Messina"] = new Keymaker();
            }
            return (Keymaker)Session["Messina"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ddlTeams.Items.Add("");
            List<Profile> allTeams = Messina.GetAllTeams();
            
        }
        else { }
    }

    protected void ddlTeams_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if(ddlTeams.SelectedIndex > 0)
        {
            pnlPlayers.Visible = true;
            List<Profile> Roster = Messina.GetRoster(teamSelected);
            lbPlayers.Items.Clear();
            foreach (Profile p in Roster)
            {
                string stats = p.Position + " " + p.JNumber + " " + p.First + " " + p.Last +
                    " " + p.Age + " " + p.Height + " " + p.Weight;
                if (p.Active)
                { stats += "Active"; }
                if (p.InjuredReserve)
                { stats += "IR"; }
                lbPlayers.Items.Add(stats);// Add players stats to listbox.

            }
            imgTeam.Visible = true;
            imgTeam.ImageUrl = "~\\Images\\" + teamSelected + ".jpg;";
        }
        else { pnlPlayers.Visible = false; }
    }
}