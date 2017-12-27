using DTOLib;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_SmartVideo;

public partial class _Default : System.Web.UI.Page
{
    private SmartWCFServiceReference.SmartWCFServiceClient Service = new SmartWCFServiceReference.SmartWCFServiceClient();
    

    protected void Page_Init(object sender, EventArgs e)
    {
        //Response.Write("Init<br/>");
        if (!IsPostBack)
        {
            if (Session["Page"] == null)
            {
                Session["Page"] = 1;
            }
            ChangerPage(null, null);

            //Response.Write("!PostBack<br/>");        
        }

        //Response.Write("Count = " + Service.GetLocationsClient(Session["LocationsClient"] != null ? Session["LocationsClient"].ToString() : "null").Count());
        //Response.Write("Count = " + Service.GetLocationsClient(Session["ClientId"] != null ? Session["ClientId"].ToString() : "null").Count());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("Load<br/>");
        //this.ClientScript.RegisterClientScriptInclude(this.GetType(), "default", "Scripts/default.js");
    }
    
    protected void Search(object sender, EventArgs e)
    {

    }

    protected List<FilmDTO> ChargerFilms(int page)
    {
        return Service.GetFilmsPage(page - 1).ToList();
    }

    protected void ChangerPage(object sender, EventArgs e)
    {
        Button button = sender as Button;
        
        //Response.Write(System.Guid.NewGuid().ToString() + "<br/>");

        if (Session["Page"] == null)
        {
            Session["Page"] = 1;  
        }

        if(Session["PagesMax"] == null)
        {
            Session["PagesMax"] = Service.CountFilms() / 20;
        }

        if (button != null)
        { 
            if (button.Text.Equals("Précédent"))
            {
                Session["Page"] = (int)Session["Page"] - 1;
            }
            else if (button.Text.Equals("Suivant"))
            {
                Session["Page"] = (int)Session["Page"] + 1;
            }
            else if (button.Text.Equals("Première"))
            {
                Session["Page"] = 1;
            }
            else if (button.Text.Equals("Dernière"))
            {
                Session["Page"] = Session["PagesMax"];
            }
            else
            {
                int page = Int32.Parse(button.Text);
                int Pagination = (int)Session["Page"];
                Pagination += -(Pagination - page);
                Session["Page"] = Pagination;
            }
        }

        if ((int)Session["Page"] == 1)
            Session["i"] = (int)Session["Page"];
        else if ((int)Session["Page"] == (int)Session["PagesMax"])
            Session["i"] = (int)Session["Page"] - 2;
        else
            Session["i"] = (int)Session["Page"] - 1;

        if(Session["ListeFilms"] == null || button != null)
            Session["ListeFilms"] = ChargerFilms((int)Session["Page"]);
        
        Pagination1.Text = Session["i"].ToString();
        Pagination2.Text = ((int)Session["i"] + 1).ToString();
        Pagination3.Text = ((int)Session["i"] + 2).ToString();
        //Response.Write("ChangerPage <br/>");
    }

    protected void Louer(object sender, EventArgs e)
    {        
        String clientId = new UserManager().FindByName(User.Identity.Name).Id;
        
        //Response.Write("Id = " + FilmID.Value + "<br/>");
        //Response.Write("Duree = " + Int32.Parse(Duree.Value) + "<br/>");
        Service.AddLocationClient(clientId, Int32.Parse(FilmID.Value), DateTime.Now.AddMonths(Int32.Parse(Duree.Value)));
        //IdentityHelper.RedirectToReturnUrl("~/", Response);
    }
}