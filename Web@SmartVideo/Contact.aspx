<%@ Page Title="Nous contacter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row justify-content-center mt-3">
            <div class="col-md">
                <h2 class="text-center"><%: Title %></h2>
            </div>
        </div>
        <div class="row mt-4">
                <div class="col-md-9">
                    <iframe style="margin-left: 8rem;" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3010.9330840284592!2d5.5103942131958785!3d50.61071459697788!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x47c0f91325b8c44d%3A0x6fe4ea82943ed25a!2sRue+Peetermans+80%2C+4100+Seraing!5e0!3m2!1sfr!2sbe!4v1514308855692" width="1200" height="600" frameborder="0" style="border:0" allowfullscreen></iframe>
                </div>
                <div class="col-md-3 my-auto">

                    <address>
                        <p class="display-4">InPrES</p>
                        Rue Peetermans, 80<br />
                        Belgique <br />
                        <abbr title="Télephone :"></abbr>04/123.245.67
                    </address>

                    <address>
                        <strong>Support : </strong><a href="mailto:InPrES@hepl.be">InPrES@hepl.be</a><br />
                    </address>
                </div>
        </div>
</asp:Content>
