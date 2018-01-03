using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_SmartVideo;

public partial class Account_Rentals : Page
{
    private SmartWCFServiceReference.SmartWCFServiceClient Service = new SmartWCFServiceReference.SmartWCFServiceClient();

    protected void Page_Init(object sender, EventArgs e)
    {
        //Response.Write("Init<br/>");

        if (Session["LocationsClient"] == null && Session["FilmsLocationsClient"] == null)
            ChargerListes();
        else
        {
            ChargerListes();
            /*Response.Write("MAJ <br/>");

            List<DTOLib.LocationDTO> Locations = Session["LocationsClient"] as List<DTOLib.LocationDTO>;
            List<DTOLib.FilmDTO> Films = Session["FilmsLocationsClient"] as List<DTOLib.FilmDTO>;

            var newLocations = Service.GetLocationsClient(new UserManager().FindById(User.Identity.GetUserId()).Id).ToList().Where(x => !(Locations.Any(y => x.Id == y.Id)));
            foreach (DTOLib.LocationDTO newLocation in newLocations)
            {
                Locations.Add(newLocation);
                Films.Add(Service.GetFilmById(newLocation.IdFilm));
            }

            Session["LocationsClient"] = Locations;
            Session["FilmsLocationsClient"] = Films;*/
        }        
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        
    }

    protected void ReturnOnHomePage(object sender, EventArgs e)
    {
        IdentityHelper.RedirectToReturnUrl("~/", Response);
    }

    protected void ChargerListes()
    {
        //Response.Write("Chargement");

        List<DTOLib.LocationDTO> Locations = Service.GetLocationsClient(new UserManager().FindById(User.Identity.GetUserId()).Id).ToList();
        List<DTOLib.FilmDTO> Films = new List<DTOLib.FilmDTO>();

        foreach (DTOLib.LocationDTO Location in Locations)
        {
            Films.Add(Service.GetFilmById(Location.IdFilm));
        }
        
        Session["LocationsClient"] = Locations;
        Session["FilmsLocationsClient"] = Films;
    }
}