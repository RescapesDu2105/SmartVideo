<%@ Page Title="Se connecter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="container" id="main">
        <div class="row justify-content-center">
            <div class="col-6">
                <h2 class="text-center"><%: Title %></h2>
                <section id="loginForm" class="col-md-8 mx-auto">
                    <div>
                        <h4 class="text-center">Utilisez un compte local pour vous connecter</h4>
                        <hr />
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
                        <div class="form-check">
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="form-check-label">
                            <asp:CheckBox runat="server" ID="RememberMe" CssClass="form-check-input"/>
                                Mémoriser le mot de passe ?
                            </asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" Text="Pas encore inscris ?" CssClass="btn btn-primary mr-4" OnClick="RedirectToRegister" />
                            <asp:Button runat="server" ValidationGroup="ValidationButton" OnClick="LogIn" Text="Se connecter" CssClass="btn btn-success ml-3" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>

