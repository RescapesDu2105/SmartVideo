<%@ Page Title="Qui sommes-nous ?" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/about.js"></script>

    <div class="row justify-content-center mt-3">
        <h2><%: Title %></h2>
    </div>
    <br /><br /><br /><br />
    <div class="row justify-content-center">
        <div class="col-md-4 d-flex ">
            <img class="img-circle rounded-circle border border-dark" src="/Content/Philippe.jpg" alt="First slide">
            <div class="my-auto ml-5">
                <h4>Philippe "Zeydax" Dimartino</h4>
                <h5>Analyste programmeur</h5>
            </div>
        </div>
    </div>
    <div class="row justify-content-center mt-5">        
        <div class="col-md-4 d-flex">    
            <img class="img-circle rounded-circle border border-dark" src="/Content/Quentin.jpg" alt="First slide">
            <div class="my-auto ml-5">
                <h4>Quentin "Doublon" Tusset</h4>
                <h5>Analyste programmeur</h5>
            </div>
        </div>
    </div>

</asp:Content>
