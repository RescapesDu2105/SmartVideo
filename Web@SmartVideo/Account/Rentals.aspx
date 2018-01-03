<%@ Page Title="Vos locations de films" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Rentals.aspx.cs" Inherits="Account_Rentals" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="<%=ResolveUrl("~/Scripts/rental.js")%>" type="text/javascript"></script>

    <div class="container" id="main">
        <div class="row justify-content-center">
            <div class="col-10">
                <h2 class="text-center"><%: Title %></h2>
                <section id="rentals" class="mx-auto">
                <%
                    List<DTOLib.LocationDTO> Locations = Session["LocationsClient"] as List<DTOLib.LocationDTO>;
                    List<DTOLib.FilmDTO> Films = Session["FilmsLocationsClient"] as List<DTOLib.FilmDTO>;

                    if (Locations != null && Locations.Count > 0)
                    { %>
                        <table class ="table table-hover mt-5">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col" class="text-center">Poster du film</th>
                                    <th scope="col" class="text-center">Titre du film</th>
                                    <th scope="col" class="text-center">Date d'expiration</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                            <%
                                foreach (DTOLib.LocationDTO Location in Locations)
                                {
                                    DTOLib.FilmDTO Film = Films.Find(x => x.Id == Location.IdFilm);
                                %>
                                <tr>
                                    <th id="poster" scope="row">
                                        <img class="rounded float-left" alt="No free image man (en)" src="<%: !Film.PosterPath.Equals("") ? ("http://image.tmdb.org/t/p/w92" + Film.PosterPath) : "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg" %>"/>
                                    </th>
                                    <td class="align-middle text-center"><%: Film.Title %></td>
                                    <td class="align-middle text-center"><%: Location.DateFin %></td>
                                    <td class="align-middle text-center">
                                        <button type="button" class="btn btn-danger ml-1" data-toggle="modal" data-target="#Modal" data-trailer="<%: Film.TrailerPath %>">
                                                Visualiser le film                                         
                                                <i class="fas fa-angle-right" aria-hidden="true"></i>
                                        </button>
                                    </td>
                                </tr>
                            <%  }%>                            
                            </tbody>
                        </table>                       
                <%  } %> 
                </section>
                
                <div class="row justify-content-center">
                    <a href="../" class="btn btn-primary"><i class="fas fa-angle-left" aria-hidden="true"></i> Retour sur la page principale</a>
                </div>

                <div class="modal fade" id="Modal" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="ModalLabel">Visualisation de votre film</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe id="player" width="1903" height="764" src="" frameborder="0" gesture="media" allow="encrypted-media" allowfullscreen></iframe>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button id="fermerVisu" type="button" class="btn btn-danger" data-dismiss="modal">Fermer</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>