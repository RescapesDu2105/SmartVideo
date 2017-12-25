<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row justify-content-md-center">
        <div class="col col-md-3">
            <form class="form-inline">
                <div class="input-group">
                    <input class="form-control ml-5" type="search" placeholder="Nom d'un film ou d'un acteur" aria-label="Search">
                    <asp:Button runat="server" OnClick="Search" Text="Chercher" CssClass="btn btn-success ml-1"></asp:Button>
                </div>
            </form>
        </div>
    </div>

    <hr />
    
    <div class="row justify-content-center">
    <nav>
        <ul class="pagination">
            <%  int iMax;                

                iMax = (int)Session["i"] + 3;

                if ((int)Session["Page"] > 1)
                {%>            
                    <li class="page-item"><asp:Button runat="server" ID="PaginationP" CssClass="page-link" Text="Première" OnClick="ChangerPage" ></asp:Button></li>
                    <li class="page-item"><asp:Button runat="server" CssClass="page-link" Text="Précédent" OnClick="ChangerPage" ></asp:Button></li>
            <%  } %>
                
                <li class="page-item <%: Int32.Parse(Pagination1.Text) == (int)Session["Page"] ? "active" : null %>"><asp:Button ID="Pagination1" runat="server" CssClass="page-link" OnClick="ChangerPage"/></li>
                <li class="page-item <%: Int32.Parse(Pagination2.Text) == (int)Session["Page"] ? "active" : null %>"><asp:Button ID="Pagination2" runat="server" CssClass="page-link" OnClick="ChangerPage"/></li>
                <li class="page-item <%: Int32.Parse(Pagination3.Text) == (int)Session["Page"] ? "active" : null %>"><asp:Button ID="Pagination3" runat="server" CssClass="page-link" OnClick="ChangerPage"/></li>
           
            <% if ((int)Session["Page"] < (int)Session["PagesMax"])
               { %>
                    <li class="page-item"><asp:Button runat="server" CssClass="page-link" Text="Suivant" OnClick="ChangerPage" ></asp:Button></li>
                    <li class="page-item"><asp:Button runat="server" ID="PaginationD" CssClass="page-link" Text="Dernière" OnClick="ChangerPage" ></asp:Button></li>
            <% } %>
        </ul>
    </nav>
        </div>
    <div class="row">
        <div class="col">
            <%  if (ListeFilms.Count > 0)
                {
                    for (int row = 0; row < 4; row++)
                    { %>
                        <div class="card-group">
                        <%  for (int col = (10 * row); ListeFilms.Count > col && col < (10 * (row+1)) ; col++)
                            {
                                DTOLib.FilmDTO Film = ListeFilms.ElementAt(col);
                                %>
                                <div class="card" style="width: 150px;">
                                    <img class="card-img-top" src="<%: !Film.PosterPath.Equals("") ? ("http://image.tmdb.org/t/p/original" + Film.PosterPath) : "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg" %>"/>
                                    <div class="card-body">
                                        <h4 class="card-title"><%: Film.Title %> </h4>
                                        <p class="card-text"><small class="text-muted"><%: Film.Original_Title %></small></p>
                                    </div>
                                </div>
                        <%  } %>
                        </div>
                <%  }
                }%>
        </div>
    </div>
</asp:Content>