<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack)
                this.Pagination1.DataBind();            
        }
    </script>
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
                

                iMax = I + 3;
                
                /*Response.Write("Pagination = " + Pagination);
                Response.Write("i = " + I);
                Response.Write("iMax = " + iMax);*/


                if (Pagination > 1)
                {%>
                    <li class="page-item"><asp:Button runat="server" CssClass="page-link" Text="Précédent" OnClick="ChangerPage" ></asp:Button></li>
            <%  } %>

                
                              
                    <li class="page-item <%: I == Pagination ? "active" : null %>"><asp:Button ID="Pagination1" runat="server" CssClass="page-link"/></li>
                    <li class="page-item <%: I == Pagination ? "active" : null %>"><asp:Button ID="Pagination2" runat="server" CssClass="page-link"/></li>
                    <li class="page-item <%: I == Pagination ? "active" : null %>"><asp:Button ID="Pagination3" runat="server" CssClass="page-link"/></li>
           
            <!--<li class="page-item active">
                <a class="page-link" href="#">2 <span class="sr-only">(current)</span></a>
            </li>
            <li class="page-item"><a class="page-link" href="#">3</a></li> -->
            <% if (Pagination < PagesMax)
               { %>
                    <li class="page-item"><a class="page-link" href="#">Suivant</a></li>
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
                                    <img class="card-img-top" src="http://image.tmdb.org/t/p/original<%: Film.PosterPath %>"/>
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