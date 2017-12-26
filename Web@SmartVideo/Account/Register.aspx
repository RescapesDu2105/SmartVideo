<%@ Page Title="Inscription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container" id="main">        
        <div class="row justify-content-center">
            <div class="col-6">
                <div class="form-horizontal col-md-8 mx-auto">
                    <h2 class="text-center"><%: Title %></h2>
                    <p class="text-danger text-center">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <h4 class="text-center">Créez un nouveau compte</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email">Adresse email</asp:Label>
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="Le champ de l'adresse email est obligatoire" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FirstName">Nom</asp:Label>
                        <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="FirstName"
                            CssClass="text-danger" ErrorMessage="Le champ du nom est obligatoire" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="LastName">Prénom</asp:Label>
                        <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="LastName"
                            CssClass="text-danger" ErrorMessage="Le champ du prénom est obligatoire" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName">Nom d'utilisateur</asp:Label>
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="UserName"
                            CssClass="text-danger" ErrorMessage="Le champ du nom d'utilisateur est obligatoire" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password">Mot de passe</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="Le champ du mot de passe est obligatoire" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirmer le mot de passe</asp:Label>
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationButton" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Le champ de confirmation du mot de passe est obligatoire" />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Le mot de passe et le mot de passe de confirmation ne correspondent pas." />
                    </div>
                    <div class="form-group">
                         <asp:Button runat="server" Text="Retour sur la page principale" OnClick="ReturnOnHomePage" CssClass="btn btn-primary" />
                         <asp:Button runat="server" ValidationGroup="ValidationButton" OnClick="CreateUser_Click" Text="S'inscrire" CssClass="btn btn-success ml-2" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

