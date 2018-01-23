<%@ Page Title="Statistiques" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Statistiques.aspx.cs" Inherits="_Statistiques" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">     

    <div class="row justify-content-center mt-3">
        <div class="col-md">
            <h2 class="text-center"><%: Title %></h2>
        </div>
        
        <%  List<DTOLib.StatistiquesDTO> StatsFilms = Application["StatsFilms"] as List<DTOLib.StatistiquesDTO>;
            List<DTOLib.FilmDTO> FilmsStats = Application["FilmsStats"] as List<DTOLib.FilmDTO>; 
            List<DTOLib.StatistiquesDTO> StatsActeurs = Application["StatsActeurs"] as List<DTOLib.StatistiquesDTO>;
            List<DTOLib.ActorDTO> ActeursStats = Application["ActeursStats"] as List<DTOLib.ActorDTO>; 
            %>        
    </div>
    <%  if (StatsFilms.Count == 0 && StatsActeurs.Count == 0)
        { %>
            <div class="row justify-content-md-center mt-4 mb-2">
                <div id="alert" class="alert alert-info" role="alert">Aucune statistique à afficher !</div>
            </div>
    <%  }
        else
        {%>
            <div class="row mt-4 justify-content-center mb-5">
                <div class="col-md-6">
                    <h4>Top 3 des films :</h4>
                <%  if (StatsFilms.Count == 0)
                    { %>
                        <div class="row justify-content-md-center mt-4 mb-2">
                            <div id="alert" class="alert alert-info" role="alert">Aucune statistique sur les acteurs à afficher !</div>
                        </div>
               <%   }
                    else
                    {%>
                        <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col">Top</th>
                                    <th scope="col">Nom du film</th>
                                    <th scope="col">Nombre de hits</th>
                                </tr>
                            </thead>
                            <tbody>
                            <%  StatsFilms = StatsFilms.OrderByDescending(s => s.NombreHits).ToList();
                                for (int i = 0; i < StatsFilms.Count; i++)
                                {
                                    DTOLib.StatistiquesDTO Stats = StatsFilms.ElementAt(i);
                                    DTOLib.FilmDTO Film = FilmsStats.Where(fs => fs.Id == Stats.IdType).SingleOrDefault();
                                    %>
                                    <tr>
                                        <th scope="row"><%= i+1 %></th>
                                        <th><%= Film.Title %></th>
                                        <td><%= Stats.NombreHits %></td>
                                    </tr>
                           <%   } %>
                            </tbody>
                        </table>
                 <% } %>
                    <br />
                    <h4>Top 3 des acteurs :</h4>
                <%  if (StatsActeurs.Count == 0)
                    { %>
                        <div class="row justify-content-md-center mt-4 mb-2">
                            <div id="alert" class="alert alert-info" role="alert">Aucune statistique sur les acteurs à afficher !</div>
                        </div>
                <%  }
                    else
                    {%>
                    <table class="table">
                        <thead class="thead-dark">
                            <tr>
                                <th scope="row">Top</th>
                                <th scope="col">Nom du film</th>
                                <th scope="col">Nombre de hits</th>
                            </tr>
                        </thead>
                        <tbody>
                        <%  StatsActeurs = StatsActeurs.OrderByDescending(s => s.NombreHits).ToList();
                            for (int i = 0; i < StatsActeurs.Count; i++)
                            {
                                DTOLib.StatistiquesDTO Stats = StatsActeurs.ElementAt(i);
                                DTOLib.ActorDTO Actor = ActeursStats.Where(fs => fs.Id == Stats.IdType).SingleOrDefault();
                                %>
                                <tr>
                                    <th scope="row"><%= i+1 %></th>
                                    <th><%= Actor.Name %></th>
                                    <td><%= Stats.NombreHits %></td>
                                </tr>
                       <%   } %>
                        </tbody>
                    </table>
                <%  } %>
                </div>
            </div>
    <%  } %>
</asp:Content>