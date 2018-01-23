using DTOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Statistiques : Page
{
    private SmartWCFServiceReference.SmartWCFServiceClient Service = new SmartWCFServiceReference.SmartWCFServiceClient();

    protected void Page_Init(object sender, EventArgs e)
    {   
        /*if (!IsPostBack)
        {*/
            List<StatistiquesDTO> StatsFilms = Service.GetStatistiquesFilms().ToList();
            List<FilmDTO> FilmsStats = new List<FilmDTO>();
            List<StatistiquesDTO> StatsActeurs = Service.GetStatistiquesActeurs().ToList();
            List<ActorDTO> ActeursStats = new List<ActorDTO>();
        
            foreach(StatistiquesDTO stats in StatsFilms)
            {
                FilmsStats.Add(Service.GetFilmById(stats.IdType));
            }

            foreach(StatistiquesDTO stats in StatsActeurs)
            {
                ActeursStats.Add(Service.GetActorByIdActor(stats.IdType));
            }

            Application["StatsFilms"] = StatsFilms;
            Application["FilmsStats"] = FilmsStats;
            Application["StatsActeurs"] = StatsActeurs;
            Application["ActeursStats"] = ActeursStats;
        //}
    }
}