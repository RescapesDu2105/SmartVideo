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
        if (!IsPostBack)
        {
            if (Session["Page"] == null)
            {
                Session["Page"] = 1;
            }
            ChangerPage(null, null);

            //Response.Write("!PostBack<br/>");        
        }
        //Response.Write("Init : " + (Session["ListeFilms"] as List<FilmDTO>).Count + " <br/>");
        //ChangerPage(null, null);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("Load<br/>");
    }
    
    protected void Search(object sender, EventArgs e)
    {
        if (!SearchInput.Text.Equals(""))
        {
            Session["SearchInput"] = SearchInput.Text;
            if ((sender as LinkButton).Text.Equals("Chercher par rapport au nom du film"))
            {

                int Count = Service.CountFilmsRecherche("Film", (String)Session["SearchInput"]);
                if (Count != 0)
                {
                    if (Count == 1)
                    {
                        FilmDTO Film = Service.GetFilmByName((String)Session["SearchInput"]);
                        if(Film != null)
                        {
                            Service.AddHits(new UserManager().FindById(User.Identity.GetUserId()).Id, Film.Id, new DateTime(), "Film");
                        }
                    }

                    Session["Recherche"] = "Film";
                    Session["ListeFilms"] = ChargerFilms(1);
                    Session["PagesMax"] = (int)Math.Ceiling(Count / 20.0);
                    Response.Write("Count = " + Count + " <br/>");

                    if ((int)Session["PagesMax"] < 3)
                    {
                        Pagination3.Visible = false;

                        if ((int)Session["PagesMax"] < 2)
                            Pagination2.Visible = false;
                        else
                            Pagination2.Visible = true;
                    }
                    else
                    {
                        Pagination3.Visible = true;
                        Pagination2.Visible = true;
                    }
                }
            }
            else
            {
                int Count = Service.CountFilmsRecherche("Actor", (String)Session["SearchInput"]);
                if (Count != 0)
                {                    
                    ActorDTO Actor = Service.IsActorExists((String)Session["SearchInput"]);
                    if (Actor != null)
                    {
                        Service.AddHits(new UserManager().FindById(User.Identity.GetUserId()).Id, Actor.Id, new DateTime(), "Actor");
                    }

                    Session["Recherche"] = "Actor";
                    Session["ListeFilms"] = ChargerFilms(1).ToList();
                    Session["PagesMax"] = Count / 20;
                    Response.Write("Count 2 = " + (int)Session["PagesMax"] + " <br/>");

                    if ((int)Session["PagesMax"] < 3)
                    {
                        Pagination3.Visible = false;

                        if ((int)Session["PagesMax"] < 2)
                            Pagination2.Visible = false;
                        else
                            Pagination2.Visible = true;
                    }
                    else
                    {
                        Pagination3.Visible = true;
                        Pagination2.Visible = true;
                    }
                }
            }

            Session["Page"] = 1;
            Session["i"] = 1;
        }
        else
            ChangerPage(null, null);


        Response.Write("Search<br/>");
    }

    protected List<FilmDTO> ChargerFilms(int page)
    {
        //Response.Write("Recherche = " + Session["Recherche"] + "<br/>");

        if (Session["Recherche"] == null)
            return Service.GetFilmsPage(page - 1).ToList();
        else
            return Service.GetFilms((String)Session["Recherche"], (String)Session["SearchInput"], page - 1).ToList();
    }

    protected void ChangerPage(object sender, EventArgs e)
    {
        Button button = sender as Button;        

        if (Session["Page"] == null)
        {
            Session["Page"] = 1;  
        }

        if(Session["PagesMax"] == null)
        {
            Session["PagesMax"] = Service.CountFilms() / 20;

            if ((int)Session["PagesMax"] < 3)
            {
                Pagination3.Visible = false;

                if ((int)Session["PagesMax"] < 2)
                    Pagination2.Visible = false;
                else
                    Pagination2.Visible = true;
            }
            else
            {
                Pagination3.Visible = true;
                Pagination2.Visible = true;
            }
        }

        if (button != null)
        { 
            if (button.Text.Equals("<<"))
            {
                Session["Page"] = (int)Session["Page"] - 1;
            }
            else if (button.Text.Equals(">>"))
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
        else if((int)Session["PagesMax"] != 2)
            if ((int)Session["Page"] == (int)Session["PagesMax"])
                Session["i"] = (int)Session["Page"] - 2;
            else
                Session["i"] = (int)Session["Page"] - 1;
        else if ((int)Session["Page"] == (int)Session["PagesMax"])
            Session["i"] = (int)Session["Page"] - 1;

        if (Session["ListeFilms"] == null || button != null)
            Session["ListeFilms"] = ChargerFilms((int)Session["Page"]);
        
        
        Pagination1.Text = Session["i"].ToString();
        Pagination2.Text = ((int)Session["i"] + 1).ToString();
        Pagination3.Text = ((int)Session["i"] + 2).ToString();

        //Response.Write("ChangerPage <br/>");
    }

    protected void Louer(object sender, EventArgs e)
    {        
        String clientId = new UserManager().FindById(User.Identity.GetUserId()).Id;
        
        Service.AddLocationClient(clientId, Int32.Parse(FilmID.Value), DateTime.Now.AddMonths(Int32.Parse(Duree.Value)));
    }

    protected void Reset(object sender, EventArgs e)
    {
        Session["Page"] = 1;
        Session["i"] = 1;
        Session["PagesMax"] = Service.CountFilms() / 20;
        Session.Remove("Recherche");

        Session["ListeFilms"] = ChargerFilms(1);

        Pagination1.Text = 1.ToString();
        Pagination2.Text = 2.ToString();
        Pagination3.Text = 3.ToString();

        Pagination2.Visible = true;
        Pagination3.Visible = true;

        SearchInput.Text = null;
        Session.Remove("SearchInput");
    }
}