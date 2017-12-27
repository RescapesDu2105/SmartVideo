<%@ Page Title="Se connecter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="container" id="main">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <h2 class="text-center"><%: Title %></h2>
                <h4 class="text-center">Utilisez un compte local pour vous connecter</h4>
                <hr />
            </div>
         </div>
        <div class="row justify-content-center mt-5">
            <div id="loginForm" class="col-md-4 mx-auto">
                <div>
                    
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger text-center">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName">Nom d'utilisateur</asp:Label>
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="UserName" CssClass="text-danger" ErrorMessage="Le champ du nom d'utilisateur est obligatoire" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password">Mot de passe</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Le champ du mot de passe est obligatoire" />
                    </div>
                    <div class="form-check d-flex justify-content-center">
                        <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="form-check-label">
                        <asp:CheckBox runat="server" ID="RememberMe" CssClass="form-check-input"/>
                            Mémoriser le mot de passe ?
                        </asp:Label>
                    </div>
                    <div class="form-group d-flex justify-content-center btn-group">
                        <asp:Button runat="server" Text="Pas encore inscris ?" CssClass="btn btn-primary" OnClick="RedirectToRegister" />
                        <asp:Button runat="server" ValidationGroup="ValidationButton" OnClick="LogIn" Text="Se connecter" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

