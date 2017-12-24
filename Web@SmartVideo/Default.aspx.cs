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
    public int Pagination { get; private set; }
    public int PagesMax { get; private set; }
    public int I { get; set; }

    private SmartWCFServiceReference.SmartWCFServiceClient Service;

    protected void Page_Init(object sender, EventArgs e)
    {
        Service = new SmartWCFServiceReference.SmartWCFServiceClient();
        Pagination = 1;
        ListeFilms = ChargerFilms(Pagination);

        I = 1;
        /*if (!IsPostBack)
            Pagination1.DataBind();*/
        Pagination1.Text = I.ToString();
        Pagination2.Text = (I + 1).ToString();
        Pagination3.Text = (I + 2).ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
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
        PagesMax = Service.CountFilms()/20;
        return Service.GetFilmsPage(page - 1).ToList();
    }
    
    protected void ChangerPage(object sender, EventArgs e)
    {
        Button button = sender as Button;

        if(button.Text.Equals("Précédent"))
            Pagination--;
        else if (button.Text.Equals("Suivant"))
            Pagination++;
        else
        {
            int page = Int32.Parse(button.Text);

            Response.Write(Pagination);
            Pagination += (Pagination - page);
            Response.Write(Pagination);
        }

        ListeFilms = ChargerFilms(Pagination);

        if (Pagination == 1)
            I = Pagination;
        else if (Pagination == PagesMax)
            I = Pagination - 2;
        else
            I = Pagination - 1;
    }
}