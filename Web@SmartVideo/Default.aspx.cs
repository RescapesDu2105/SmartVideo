using DTOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public List<FilmDTO> ListeFilms { get; private set; }
    //public int Pagination { get; private set; }
    //public int PagesMax { get; private set; }
   // public int I { get; set; }
    private SmartWCFServiceReference.SmartWCFServiceClient Service;
    

    protected void Page_Init(object sender, EventArgs e)
    {
        //Response.Write("Init<br/>");
        Service = new SmartWCFServiceReference.SmartWCFServiceClient();
        if (!IsPostBack)
        {
            if (Session["Page"] == null)
            {
                Session["Page"] = 1;
                //Session["i"] = 1;            
            }
            ChangerPage(null, null);
        }        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("Load<br/>");
    }
    
    protected int Test(int i)
    {
        return i;
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

        //Response.Write("Pagination avant = " + (int)Session["Page"]);
        //Response.Write("<br/>");

        //Response.Write(sender + "<br/>");
        if (Session["Page"] == null)
        {
            Session["Page"] = 1;
            //Session["i"] = 1;            
        }

        if(Session["PagesMax"] == null)
        {
            Session["PagesMax"] = Service.CountFilms() / 20;
            //Response.Write(Session["PagesMax"] + " <br/>");
        }

        if (button != null)
        { 
            if (button.Text.Equals("Précédent"))
            {
                //Response.Write("Prec");
                //Response.Write("<br/>");
                Session["Page"] = (int)Session["Page"] - 1;
            }
            else if (button.Text.Equals("Suivant"))
            {
                //Response.Write("Suiv");
                //Response.Write("<br/>");
                Session["Page"] = (int)Session["Page"] + 1;
            }
            else if (button.Text.Equals("Première"))
            {
                Session["Page"] = 1;
            }
            else if (button.Text.Equals("Dernière"))
            {
                //Response.Write(Session["PagesMax"] + " <br/>");
                Session["Page"] = Session["PagesMax"];
            }
            else
            {
                int page = Int32.Parse(button.Text);
                int Pagination = (int)Session["Page"];
                //Response.Write(Pagination);
                //Response.Write("<br/>");
                Pagination += -(Pagination - page);
                Session["Page"] = Pagination;
                //Response.Write(Pagination);
            }
        }

        //Response.Write("Pagination après = " + (int)Session["Page"]);
        //Response.Write("<br/>");

        //ListeFilms = ChargerFilms(Pagination);

        if ((int)Session["Page"] == 1)
            Session["i"] = (int)Session["Page"];
        else if ((int)Session["Page"] == (int)Session["PagesMax"])
            Session["i"] = (int)Session["Page"] - 2;
        else
            Session["i"] = (int)Session["Page"] - 1;


        ListeFilms = ChargerFilms((int)Session["Page"]);

        //Response.Write("P1 " + Pagination1.Text + "<br/>");
        Pagination1.Text = Session["i"].ToString();
        //Response.Write("P1 " + Pagination1.Text + "<br/>");
        //Response.Write("P2 " + Pagination2.Text + "<br/>");
        Pagination2.Text = ((int)Session["i"] + 1).ToString();
        //Response.Write("P2 " + Pagination2.Text + "<br/>");
        //Response.Write("P3 " + Pagination3.Text + "<br/>");
        Pagination3.Text = ((int)Session["i"] + 2).ToString();
        //Response.Write("P3 " + Pagination3.Text + "<br/>");

        //Response.Write("i = " + Session["i"]);
        //Response.Write("ChangerPage <br/>");
    }
}