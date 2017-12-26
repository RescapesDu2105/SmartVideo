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
            if (Application["Page"] == null)
            {
                Application["Page"] = 1;
            }
            ChangerPage(null, null);

            //Response.Write("!PostBack<br/>");        
        }        
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

        if (Application["Page"] == null)
        {
            Application["Page"] = 1;  
        }

        if(Application["PagesMax"] == null)
        {
            Application["PagesMax"] = Service.CountFilms() / 20;
        }

        if (button != null)
        { 
            if (button.Text.Equals("Précédent"))
            {
                Application["Page"] = (int)Application["Page"] - 1;
            }
            else if (button.Text.Equals("Suivant"))
            {
                Application["Page"] = (int)Application["Page"] + 1;
            }
            else if (button.Text.Equals("Première"))
            {
                Application["Page"] = 1;
            }
            else if (button.Text.Equals("Dernière"))
            {
                Application["Page"] = Application["PagesMax"];
            }
            else
            {
                int page = Int32.Parse(button.Text);
                int Pagination = (int)Application["Page"];
                Pagination += -(Pagination - page);
                Application["Page"] = Pagination;
            }
        }

        if ((int)Application["Page"] == 1)
            Application["i"] = (int)Application["Page"];
        else if ((int)Application["Page"] == (int)Application["PagesMax"])
            Application["i"] = (int)Application["Page"] - 2;
        else
            Application["i"] = (int)Application["Page"] - 1;

        if(Application["ListeFilms"] == null || button != null)
            Application["ListeFilms"] = ChargerFilms((int)Application["Page"]);
        
        Pagination1.Text = Application["i"].ToString();
        Pagination2.Text = ((int)Application["i"] + 1).ToString();
        Pagination3.Text = ((int)Application["i"] + 2).ToString();
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