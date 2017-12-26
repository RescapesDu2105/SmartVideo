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
    private SmartWCFServiceReference.SmartWCFServiceClient Service = new SmartWCFServiceReference.SmartWCFServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Validate the user password
            var manager = new UserManager();
            
            ApplicationUser user = manager.Find(UserName.Text, Password.Text);
            
            if (user != null)
            {
                IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                //Session.Add("LocationsClient", Service.GetLocationsClient(user.Id));
                //Session.Add("ClientId", user.Id);
            }
            else
            {
                FailureText.Text = "Nom d'utilisateur et/ou mot de passe incorrect(s) !";
                ErrorMessage.Visible = true;
            }
        }
    }

    protected void RedirectToRegister(object sender, EventArgs e)
    {
        IdentityHelper.RedirectToReturnUrl("~/Account/Register", Response);
    }
}