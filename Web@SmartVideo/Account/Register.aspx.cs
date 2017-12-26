using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using Web_SmartVideo;
using System.Net.Mail;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        try
        {
            MailAddress mail = new MailAddress(Email.Text);

            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = UserName.Text, Email = mail.Address, EmailConfirmed = true, FirstName = FirstName.Text, LastName = LastName.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
        catch(FormatException ex)
        {
            ErrorMessage.Text = ex.Message;
        }        
    }

    protected void ReturnOnHomePage(object sender, EventArgs e)
    {
        IdentityHelper.RedirectToReturnUrl("~/", Response);
    }
}