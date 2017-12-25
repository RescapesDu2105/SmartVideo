using DTOLib;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Web_SmartVideo;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "Register";
        //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
        //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        /*if (!String.IsNullOrEmpty(returnUrl))
        {
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        }*/
    }

    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Validate the user password
            var manager = Context.GetOwinContext().GetUserManager<UserManager>();

            SmartWCFServiceReference.SmartWCFServiceClient service = new SmartWCFServiceReference.SmartWCFServiceClient();
            List<ClientDTO> Clients = new List<ClientDTO>(service.GetClients());

            ApplicationUser user;
            foreach (ClientDTO client in Clients)
            {
                user = new ApplicationUser();
                user.Id = client.Id.ToString();
                user.UserName = client.Login;
                manager.Create(user, client.Password);
            }

            user = manager.Find(UserName.Text, Password.Text);
            
            if (user != null)
            {
                IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                FailureText.Text = "Nom d'utilisateur et/ou mot de passe incorrect(s) !";
                ErrorMessage.Visible = true;
            }

                
        }
    }
}