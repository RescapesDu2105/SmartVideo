<%@ Page Title="Home page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">    
    <script src="<%=ResolveUrl("~/Scripts/default.js")%>" type="text/javascript"></script>

    <div class="row justify-content-md-center mt-4 mb-5">
        <div class="col col-md-3">
            <form class="form-inline">
                <div class="input-group">
                    <input class="form-control ml-5" type="search" placeholder="Nom d'un film ou d'un acteur" aria-label="Search">
                    <span class="input-group-btn">                        
                        <asp:Button runat="server" OnClick="Search" Text="Chercher" CssClass="btn btn-success"></asp:Button>
                    </span>
                </div>
            </form>
        </div>
    </div>

    <hr />
    
    <div class="row justify-content-center mt-4">
        <nav>
            <ul class="pagination">
                <%  int iMax;
                    
                    iMax = (int)Application["i"] + 3;

                    if ((int)Application["Page"] > 1)
                    {%>            
                        <li class="page-item"><asp:Button runat="server" ID="PaginationP" CssClass="page-link" Text="Première" OnClick="ChangerPage" ></asp:Button></li>
                        <li class="page-item"><asp:Button runat="server" CssClass="page-link" Text="Précédent" OnClick="ChangerPage" ></asp:Button></li>
                <%  } %>
                
                    <li class="page-item <%: Int32.Parse(Pagination1.Text) == (int)Application["Page"] ? "active" : null %>"><asp:Button ID="Pagination1" runat="server" CssClass="page-link" OnClick="ChangerPage"/></li>
                    <li class="page-item <%: Int32.Parse(Pagination2.Text) == (int)Application["Page"] ? "active" : null %>"><asp:Button ID="Pagination2" runat="server" CssClass="page-link" OnClick="ChangerPage"/></li>
                    <li class="page-item <%: Int32.Parse(Pagination3.Text) == (int)Application["Page"] ? "active" : null %>"><asp:Button ID="Pagination3" runat="server" CssClass="page-link" OnClick="ChangerPage"/></li>
           
                <% if ((int)Application["Page"] < (int)Application["PagesMax"])
                   { %>
                        <li class="page-item"><asp:Button runat="server" CssClass="page-link" Text="Suivant" OnClick="ChangerPage" ></asp:Button></li>
                        <li class="page-item"><asp:Button runat="server" ID="PaginationD" CssClass="page-link" Text="Dernière" OnClick="ChangerPage" ></asp:Button></li>
                <% } %>
            </ul>
        </nav>
    </div>
    <div class="row mt-2">
        <div class="col">
            <%  
                List<DTOLib.FilmDTO> ListeFilms = Application["ListeFilms"] as List<DTOLib.FilmDTO>;
                if (ListeFilms != null && ListeFilms.Count > 0)
                {
                    for (int row = 0; row < 4; row++)
                    { %>
                        <div class="card-group mb-1">
                        <%  for (int col = (10 * row); ListeFilms.Count > col && col < (10 * (row+1)) ; col++)
                            {
                                DTOLib.FilmDTO Film = ListeFilms.ElementAt(col);
                                %>
                                <div class="card bg-dark text-white" id="film" data-toggle="modal" data-target="#ModalLouer" data-id="<%: Film.Id %>" data-title="<%: Film.Title %>" data-posterpath="<%: !Film.PosterPath.Equals("") ? ("http://image.tmdb.org/t/p/original" + Film.PosterPath) : "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg" %>">
                                    <img class="card-img my-auto" src="<%: !Film.PosterPath.Equals("") ? ("http://image.tmdb.org/t/p/original" + Film.PosterPath) : "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg" %>"/>
                                    <!--<div class="card-img-overlay">
                                        <h4 class="card-title"><%: Film.Title %> </h4>
                                        <p class="card-text"><small class="text-muted"><%: Film.Original_Title %></small></p>
                                    </div> -->
                                </div>
                        <%  } %>
                        </div>
                <%  }
                }%>
        </div>
    </div>

    <div class="modal fade" id="ModalLouer" tabindex="-1" role="dialog" aria-labelledby="ModalLouerLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLouerLabel">Louer ce film ?</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                            <img class="card-img my-auto rounded border border-dark" src="https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg"/>
                        </div>
                        <div class="col">
                            <h5 class="text-center"></h5>
                            <hr />
                            <p class="text-center font-weight-bold">Durée de la location :</p>
                            <div class="form-inline ml-5">
                                <input runat="server" class="form-control col-md-5" ID="Duree" type="number" name="duree" min="3" max="12" value="3" />
                                <asp:Label runat="server" AssociatedControlID="Duree" CssClass="font-weight-normal ml-2"> Mois</asp:Label>
                                <input runat="server" type="hidden" ID="FilmID"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">                    
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Annuler</button>
                    <asp:Button runat="server" class="btn btn-success" Text="Oui, je veux le louer !" OnClick="Louer"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>